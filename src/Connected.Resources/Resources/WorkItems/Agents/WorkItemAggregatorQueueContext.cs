using Connected.Collections.Queues;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.WorkItems.Agents
{
	internal sealed class WorkItemAggregatorQueueContext(IStorageProvider storage, IWorkItemAggregatorQueueCache cache)
				: QueueContext<WorkItemAggregatorQueueMessage, WorkItemAggregatorQueueAction, IPrimaryKeyDto<long>>(storage, cache)
	{
	}
}
