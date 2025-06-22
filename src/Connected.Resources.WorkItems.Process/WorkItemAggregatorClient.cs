using Connected.Collections.Queues;
using Connected.Services;

namespace Connected.Resources.WorkItems;

internal class WorkItemAggregatorClient(IWorkItemService workItems) : QueueClient<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = await workItems.Select(Dto);

		if (entity is null)
			return;

		var children = await workItems.Query(Dto.CreateHead(entity.Id));
		var props = new Dictionary<string, object?>
		{
			{ nameof(IWorkItem.Estimation), children.Sum(f => f.Estimation) },
			{ nameof(IWorkItem.ItemCount), children.Count }
		};
		var dto = Dto.CreatePatch(entity.Id, props);

		await workItems.Patch(dto);
	}
}
