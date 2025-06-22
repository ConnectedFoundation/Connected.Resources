using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Effort;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record Effort : ConsistentEntity<long>, IEffort
{
	[Ordinal(0)]
	public int Resource { get; init; }

	[Ordinal(1)]
	public long? WorkItem { get; init; }

	[Ordinal(2)]
	public int TimeSheet { get; init; }

	[Ordinal(3), Date(DateKind.Date)]
	public DateTimeOffset Date { get; init; }

	[Ordinal(4), Length(1024)]
	public string? Description { get; init; }

	[Ordinal(5), Length(1024)]
	public string? Tags { get; init; }

	[Ordinal(6)]
	public double Value { get; init; }
}
