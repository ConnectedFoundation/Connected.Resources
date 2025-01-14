using Connected.Entities;
using Connected.Resources.TimeSheets;

namespace Connected.Resources.WorkSheets;
/// <summary>
/// This is an entity which overrides <see cref="ITimeSheetPeriodItem"/> for the
/// specific <see cref="IResource"> and <see cref="ITimeSheetPeriodItem">. For example, all sick leave or
/// vacation should be overriden with this entity.
/// </summary>
public interface IWorkSheet : IEntity<int>
{
	int TimeSheet { get; init; }
	int Resource { get; init; }
	DateTimeOffset Start { get; init; }
	DateTimeOffset? End { get; init; }
	TimeSheetPeriodType Type { get; init; }
	string? Tags { get; init; }
}