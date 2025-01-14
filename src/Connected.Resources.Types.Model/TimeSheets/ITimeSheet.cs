using Connected.Entities;

namespace Connected.Resources.TimeSheets;

public interface ITimeSheet : IEntity<int>
{
	string Title { get; init; }
	bool IsDefault { get; init; }
}