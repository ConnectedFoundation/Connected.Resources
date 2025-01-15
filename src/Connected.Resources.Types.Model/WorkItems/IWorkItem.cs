using Connected.Entities;

namespace Connected.Resources.WorkItems;

public enum WorkItemStatus
{
	Draft = 0,
	Active = 1,
	Complete = 2
}

public interface IWorkItem : IEntityContainer<long>
{
	DateTimeOffset? Start { get; init; }
	DateTimeOffset? End { get; init; }
	int? Resource { get; init; }
	int TimeSheet { get; init; }
	WorkItemStatus Status { get; init; }
	double Estimation { get; init; }
	long? Parent { get; init; }
	int? JobPosition { get; init; }
}