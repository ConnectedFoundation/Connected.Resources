using Connected.Annotations;
using Connected.Collections.Queues;
using Connected.Notifications;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.WorkItems.Agents.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Inserted)]
internal sealed class InsertWorkItemListener(
	IDebounceContext<WorkItemAggregatorQueueMessage, WorkItemAggregatorQueueCache, WorkItemAggregatorClient, long> debounce)
	: EventListener<IInsertWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		if (entity.Parent is null)
			return;

		await debounce.Invoke(entity.Parent.GetValueOrDefault(), TimeSpan.FromSeconds(10));
	}
}
