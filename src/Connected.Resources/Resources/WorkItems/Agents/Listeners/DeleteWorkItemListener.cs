using Connected.Annotations;
using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Documents.WorkItems;
using Connected.Services;

namespace Connected.Resources.Resources.WorkItems.Agents.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Deleted)]
internal sealed class DeleteWorkItemListener(
	WorkItemAggregatorQueueContext queue)
	: EventListener<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = Sender.GetState<IWorkItem>().Required();

		if (entity.Parent is not null)
			await queue.Invoke(Dto.CreatePrimaryKey(entity.Parent.GetValueOrDefault()));
	}
}
