using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Resources.Resources.Utilization;
using Connected.Resources.Resources.Utilization.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.Utilization.Agents;

internal sealed class UtilizationCalculator(IWorkItemService workItems, IResourceUtilizationService utilization, IWorkItem workItem)
{
	public async Task Calculate()
	{
		/*
		 * We are calculating only leaf work items because work items with children are
		 * aggregated by their children.
		 */

		if (workItem.Resource is null || workItem.Start is null)
			return;
		/*
		 * Note we don't rely on ItemCount property here because it is not necessary it is fully calculated on time.
		 */
		var children = await workItems.Query(Dto.Factory.CreateHead(workItem.Id));

		if (children.Any())
			return;
		/*
		 * We need to perform recalculation for the entire date span because work item can span across many
		 * days.
		 */
		var start = workItem.Start.Value.Date;
		var end = workItem.End is null ? workItem.Start.Value.Date : workItem.End.Value.Date;
		/*
		 * Now let's create a complete date range that needs to be recalculated.
		 */
		var days = CalculateDays(start, end);
		/*
		 * Just perform recalculation for every day in the work item date range.
		 */
		foreach (var day in days)
			await Calculate(workItem, day);
	}

	private async Task Calculate(IWorkItem workItem, DateTimeOffset date)
	{
		/*
		 * First, calculate utilization for the resource and date.
		 */
		var value = await CalculateUtilization(workItem.TimeSheet, workItem.Resource.GetValueOrDefault(), date.Date);
		/*
		 * See if the existing record exists.
		 */
		var selectDto = Dto.Factory.Create<ISelectResourceUtilizationDto>();

		selectDto.Resource = workItem.Resource.GetValueOrDefault();
		selectDto.Date = date.Date;

		var existing = await utilization.Select(selectDto);
		/*
		 * Doesn't exist, we need to insert a new utilization record.
		 */
		if (existing is null)
		{
			var insertDto = Dto.Factory.Create<IInsertResourceUtilizationDto>();

			insertDto.Date = date.Date;
			insertDto.Resource = workItem.Resource.GetValueOrDefault();
			insertDto.Utilization = value;

			await utilization.Insert(insertDto);
		}
		else
		{
			/*
			 * Exists, perform a patch on an existing record
			 */
			var properties = new Dictionary<string, object?>()
			{
				{ nameof(IResourceUtilization.Utilization), value }
			};
			var patchDto = Dto.Factory.CreatePatch(existing.Id, properties);

			await utilization.Patch(patchDto);
		}
	}

	private static List<DateTimeOffset> CalculateDays(DateTimeOffset start, DateTimeOffset end)
	{
		var result = new List<DateTimeOffset>();
		var date = start;

		result.Add(date.Date);

		while (date < end)
		{
			date = date.AddDays(1);

			if (date > end)
				break;

			result.Add(date);
		}

		return result;
	}

	private async Task<double> CalculateUtilization(int timeSheet, int resource, DateTimeOffset date)
	{
		var dto = Dto.Factory.Create<IQueryWorkItemsInDateDto>();

		dto.TimeSheet = timeSheet;
		dto.Resource = resource;
		dto.Date = date;

		var items = await workItems.Query(dto);

		return items.Sum(f => f.Estimation);
	}
}
