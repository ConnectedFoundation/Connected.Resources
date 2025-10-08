using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Resources.TimeSheets;

[Table(SchemaAttribute.ResourcesSchema)]
internal sealed record TimeSheet : ConsistentEntity<int>, ITimeSheet
{
	[Ordinal(0), Length(128)]
	public required string Name { get; init; }

	[Ordinal(1)]
	public bool IsDefault { get; init; }
}
