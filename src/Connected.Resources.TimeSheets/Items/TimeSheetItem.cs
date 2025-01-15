using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.TimeSheets.Items;
internal sealed record TimeSheetItem : ConsistentEntity<int>, ITimeSheetItem
{
	[Ordinal(0)]
	public int TimeSheet { get; init; }

	[Ordinal(1), Date(DateKind.DateTime)]
	public DateTimeOffset Start { get; init; }

	[Ordinal(2), Date(DateKind.DateTime)]
	public DateTimeOffset? End { get; init; }

	[Ordinal(3)]
	public TimeSheetItemType Type { get; init; }
}
