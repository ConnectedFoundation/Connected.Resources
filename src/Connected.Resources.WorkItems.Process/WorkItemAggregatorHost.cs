using Connected.Collections.Queues;

namespace Connected.Resources.WorkItems.Process;

internal sealed class WorkItemAggregatorHost : QueueHost
{
	public WorkItemAggregatorHost() : base(ResourcesMetaData.WorkItemKey, 2)
	{
	}
}
