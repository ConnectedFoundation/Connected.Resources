using Connected.Annotations;
using Connected.Collections;
using Connected.Collections.Queues;
using Connected.Notifications;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.WorkItems.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Updated)]
internal sealed class UpdateWorkItemListener(IQueueService queue, IWorkItemService workItems) : EventListener<IUpdateWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var origin = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var current = await workItems.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		/*
		 * Parent has changed. We need to recalculate the old parent as well.
		 */
		if (origin.Parent != current.Parent && origin.Parent is not null)
			await queue.Insert<WorkItemAggregatorClient, IPrimaryKeyDto<long>>(Dto.CreatePrimaryKey(origin.Parent.GetValueOrDefault()), Dto.CreateInsertOptions(ResourcesDocumentsMetaData.WorkItemKey));
		/*
		 * Recalculate current parent
		 */
		if (current.Parent is not null)
			await queue.Insert<WorkItemAggregatorClient, IPrimaryKeyDto<long>>(Dto.CreatePrimaryKey(current.Parent.GetValueOrDefault()), Dto.CreateInsertOptions(ResourcesDocumentsMetaData.WorkItemKey));
	}
}
