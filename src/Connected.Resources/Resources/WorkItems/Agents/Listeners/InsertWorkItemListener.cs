using Connected.Annotations;
using Connected.Collections;
using Connected.Collections.Queues;
using Connected.Notifications;
using Connected.Resources.Documents;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Resources.Resources.WorkItems.Agents;
using Connected.Services;

namespace Connected.Resources.Resources.WorkItems.Agents.Listeners;

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
