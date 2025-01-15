using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.WorkItems;

[Table(SchemaAttribute.ResourcesSchema)]
internal sealed record WorkItem : EntityContainer<long>, IWorkItem
{
	[Ordinal(0), Date(DateKind.SmallDateTime)]
	public DateTimeOffset? Start { get; init; }

	[Ordinal(1), Date(DateKind.SmallDateTime)]
	public DateTimeOffset? End { get; init; }

	[Ordinal(2)]
	public int? Resource { get; init; }

	[Ordinal(3), Index(false)]
	public int TimeSheet { get; init; }

	[Ordinal(4)]
	public WorkItemStatus Status { get; init; }

	[Ordinal(5)]
	public double Estimation { get; init; }

	[Ordinal(6)]
	public long? Parent { get; init; }

	[Ordinal(7)]
	public int? JobPosition { get; init; }
}
