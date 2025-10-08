using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Types.JobPositions;
internal sealed record JobPosition : ConsistentEntity<int>, IJobPosition
{
	[Ordinal(0), Length(128), Index(true)]
	public required string Code { get; init; }

	[Ordinal(1), Length(128)]
	public required string Name { get; init; }

	[Ordinal(2)]
	public Status Status { get; init; }

	[Ordinal(3)]
	public float? HourlyRate { get; init; }
}
