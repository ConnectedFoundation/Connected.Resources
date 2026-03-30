using Connected.Collections.Queues;

namespace Connected.Resources.Resources.WorkItems.Agents;

internal sealed class WorkItemAggregatorHost
	: QueueHost<WorkItemAggregatorQueueMessage, WorkItemAggregatorQueueCache>
{
}
