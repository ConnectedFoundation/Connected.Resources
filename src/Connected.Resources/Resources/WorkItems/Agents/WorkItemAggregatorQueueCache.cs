using Connected.Annotations.Entities;
using Connected.Caching;
using Connected.Collections.Queues;
using Connected.Storage;

namespace Connected.Resources.Resources.WorkItems.Agents;

internal sealed class WorkItemAggregatorQueueCache(ICachingService cache, IStorageProvider storage)
	: QueueMessageCache<WorkItemAggregatorQueueMessage>(cache, storage, $"{SchemaAttribute.LogisticsSchema}.{nameof(WorkItemAggregatorQueueCache)}")
{
}
