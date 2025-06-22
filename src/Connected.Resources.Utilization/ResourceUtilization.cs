using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Utilization;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record ResourceUtilization : ConsistentEntity<long>, IResourceUtilization
{
	[Ordinal(0)]
	public int Resource { get; init; }

	[Ordinal(1), Date(DateKind.Date)]
	public DateTimeOffset Date { get; init; }

	[Ordinal(2)]
	public double Capacity { get; init; }

	[Ordinal(3)]
	public double Utilization { get; init; }

	[Ordinal(4)]
	public double PlannedEffort { get; init; }

	[Ordinal(5)]
	public double UnplannedEffort { get; init; }
}
