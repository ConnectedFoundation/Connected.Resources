using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources;
internal sealed record Resource : ConsistentEntity<int>, IResource
{
	[Ordinal(0), Length(128), Index(true)]
	public required string Token { get; init; }

	[Ordinal(1), Length(128), Index(true)]
	public required string Code { get; init; }

	[Ordinal(2)]
	public Status Status { get; init; }

	[Ordinal(3), Length(128)]
	public string? Type { get; init; }

	[Ordinal(4)]
	public ResourceBehavior Behavior { get; init; }

	[Ordinal(5)]
	public float? HourlyRate { get; init; }

	[Ordinal(6)]
	public int? JobPosition { get; init; }
}
