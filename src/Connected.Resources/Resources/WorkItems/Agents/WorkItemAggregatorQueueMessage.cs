using Connected.Annotations.Entities;
using Connected.Collections.Queues;

namespace Connected.Resources.Resources.WorkItems.Agents;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record WorkItemAggregatorQueueMessage
	: QueueMessage
{
}
