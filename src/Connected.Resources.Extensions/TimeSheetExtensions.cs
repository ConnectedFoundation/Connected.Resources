using Connected.Resources.TimeSheets;
using Connected.Resources.TimeSheets.Dtos;
using Connected.Resources.TimeSheets.Items;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources;

public static class TimeSheetExtensions
{
	public static async Task<ITimeSheet> SelectDefault(this ITimeSheetService timeSheets)
	{
		var items = await timeSheets.Query(null);

		if (items.Count == 0)
		{
			var id = await Insert(timeSheets);

			return await timeSheets.Select(Dto.Factory.CreatePrimaryKey(id)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}

		if (items.FirstOrDefault(f => f.IsDefault) is ITimeSheet def)
			return def;
		/*
		 * Timesheet exists but it's not a default. We don't really care here, just
		 * return the first one.
		 */
		return items[0];
	}

	private static async Task<int> Insert(ITimeSheetService timeSheets)
	{
		var dto = Dto.Factory.Create<IInsertTimeSheetDto>();

		dto.IsDefault = true;
		dto.Name = "Default Timesheet";

		return await timeSheets.Insert(dto);
	}

	public static TimeSpan TotalCapacity(this IImmutableList<ITimeSheetItem> items)
	{
		var result = TimeSpan.Zero;

		foreach (var item in items)
		{
			if (item.Type == TimeSheetItemType.Unavailable)
				continue;

			var end = item.End is null ? item.Start.Date.AddDays(1).AddMilliseconds(-1) : item.End.Value;

			result.Add(end.Subtract(item.Start));
		}

		return result;
	}
}
