using Connected.Entities;

namespace Connected.Resources.Resources.TimeSheets;

public interface ITimeSheet : IEntity<int>
{
	string Name { get; init; }
	bool IsDefault { get; init; }
}