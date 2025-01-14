using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.TimeLogs;
internal sealed record TimeLog : ConsistentEntity<long>, ITimeLog
{
	[Ordinal(0), Index(false)]
	public int Resource { get; init; }

	[Ordinal(1), Date(DateKind.DateTime)]
	public DateTimeOffset Start { get; init; }

	[Ordinal(2), Date(DateKind.DateTime)]
	public DateTimeOffset? End { get; init; }

	[Ordinal(3), Length(1024)]
	public required string Type { get; init; }
}
