using Connected.Entities;

namespace Connected.Resources.WorkItems;

public enum WorkItemStatus
{
	Draft = 0,
	Active = 1,
	Completed = 2
}

public interface IWorkItem : IEntity<long>
{
	DateTimeOffset? Start { get; init; }
	DateTimeOffset? End { get; init; }
	DateTimeOffset? Activated { get; init; }
	DateTimeOffset? Completed { get; init; }

	int? Assigned { get; init; }
	int TimeSheet { get; init; }

	WorkItemStatus Status { get; init; }

	float Estimation { get; init; }

	long? Document { get; init; }
	long? Parent { get; init; }
	int? JobPosition { get; init; }
}