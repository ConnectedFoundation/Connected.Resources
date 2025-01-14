using Connected.Entities;

namespace Connected.Resources.TimeLogs;

public interface ITimeLog : IEntity<long>
{
	int Resource { get; init; }
	DateTimeOffset Start { get; init; }
	DateTimeOffset? End { get; init; }
	string Type { get; init; }
}