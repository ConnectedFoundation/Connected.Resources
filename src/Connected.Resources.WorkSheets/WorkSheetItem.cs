using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Resources.TimeSheets.Items;

namespace Connected.Resources.WorkSheets;

internal sealed record WorkSheetItem : ConsistentEntity<int>, IWorkSheetItem
{
	[Ordinal(0), Index(false)]
	public int TimeSheet { get; init; }

	[Ordinal(1), Index(false)]
	public int Resource { get; init; }

	[Ordinal(2), Index(false), Date(DateKind.DateTime)]
	public DateTimeOffset Start { get; init; }

	[Ordinal(3), Index(false), Date(DateKind.DateTime)]
	public DateTimeOffset? End { get; init; }

	[Ordinal(4)]
	public TimeSheetItemType Type { get; init; }

	[Ordinal(5), Length(1024)]
	public string? Tags { get; init; }
}
