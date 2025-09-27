using Connected.Annotations;
using Connected.Collections;
using Connected.Collections.Queues;
using Connected.Notifications;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.WorkItems.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Inserted)]
internal sealed class InsertWorkItemListener(IQueueService queue) : EventListener<IInsertWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var entity = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		if (entity.Parent is null)
			return;

		await queue.Insert<WorkItemAggregatorClient, IPrimaryKeyDto<long>>(Dto.CreatePrimaryKey(entity.Parent.GetValueOrDefault()), Dto.CreateInsertOptions(ResourcesDocumentsMetaData.WorkItemKey));
	}
}
