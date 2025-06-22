using Connected.Entities;

namespace Connected.Resources.Effort;

public interface IEffort : IEntity<long>
{
	int Resource { get; init; }
	long? WorkItem { get; init; }
	int TimeSheet { get; init; }
	DateTimeOffset Date { get; init; }
	string? Description { get; init; }
	string? Tags { get; init; }
	double Value { get; init; }
}
