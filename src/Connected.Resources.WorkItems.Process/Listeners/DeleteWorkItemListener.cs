using Connected.Annotations;
using Connected.Collections;
using Connected.Collections.Queues;
using Connected.Notifications;
using Connected.Services;

namespace Connected.Resources.WorkItems.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Deleted)]
internal sealed class DeleteWorkItemListener(IQueueService queue) : EventListener<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		if (entity.Parent is not null)
			await queue.Insert<WorkItemAggregatorClient, IPrimaryKeyDto<long>>(Dto.CreatePrimaryKey(entity.Parent.GetValueOrDefault()), Dto.CreateInsertOptions(ResourcesMetaData.WorkItemKey));
	}
}
