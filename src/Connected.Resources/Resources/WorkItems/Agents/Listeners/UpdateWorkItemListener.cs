using Connected.Annotations;
using Connected.Collections.Queues;
using Connected.Notifications;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.WorkItems.Agents.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Updated)]
internal sealed class UpdateWorkItemListener(
	WorkItemAggregatorClient queue,
	IWorkItemService workItems) 
	: EventListener<IUpdateWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var origin = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var current = await workItems.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		/*
		 * Parent has changed. We need to recalculate the old parent as well.
		 */
		if (origin.Parent != current.Parent && origin.Parent is not null)
			await queue.Invoke(Dto.CreatePrimaryKey( origin.Parent.GetValueOrDefault()));
		/*
		 * Recalculate current parent
		 */
		if (current.Parent is not null)
			await queue.Invoke(Dto.CreatePrimaryKey( current.Parent.GetValueOrDefault()));
	}
}
