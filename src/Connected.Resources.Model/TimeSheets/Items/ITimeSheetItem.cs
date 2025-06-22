using Connected.Entities;

namespace Connected.Resources.TimeSheets.Items;

public enum TimeSheetItemType
{
	Unavailable = 0,
	Available = 1
}

public interface ITimeSheetItem : IEntity<int>
{
	int TimeSheet { get; init; }
	DateTimeOffset Start { get; init; }
	DateTimeOffset? End { get; init; }
	TimeSheetItemType Type { get; init; }
}