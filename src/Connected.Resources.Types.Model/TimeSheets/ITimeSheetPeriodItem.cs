using Connected.Entities;

namespace Connected.Resources.TimeSheets;

public enum TimeSheetPeriodType
{
	Unavailable = 0,
	Available = 1
}

public interface ITimeSheetPeriodItem : IEntity<int>
{
	int TimeSheet { get; init; }
	DateTimeOffset Start { get; init; }
	DateTimeOffset? End { get; init; }
	TimeSheetPeriodType Type { get; init; }
}