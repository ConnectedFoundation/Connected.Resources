using Connected.Collections.Queues;
using Connected.Resources.Documents;

namespace Connected.Resources.Resources.WorkItems.Agents;

internal sealed class WorkItemAggregatorHost : QueueHost
{
	public WorkItemAggregatorHost() : base(ResourcesDocumentsMetaData.WorkItemKey, 2)
	{
	}
}
