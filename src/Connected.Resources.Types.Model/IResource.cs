using Connected.Entities;

namespace Connected.Resources;
/// <summary>
/// Defines how resource utilization behaves. Singleton resources (i.e. human) can
/// be utilized as an isolated resource with only one utilization stack, which means
/// every work item with the assigned resource increases utilization.Multiton resources,
/// on the other hand, increases utilization without overlapping, for example, broadcasting
/// studio can be utilized in more than one time sheet at a time but its utilization will
/// be calculated as a single timesheet use.
/// </summary>
public enum ResourceBehavior
{
	Singleton = 0,
	Multiton = 1
}

public interface IResource : IEntity<int>
{
	string Token { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
	string? Type { get; init; }
	ResourceBehavior Behavior { get; init; }
	float? HourlyRate { get; init; }
	int? JobPosition { get; init; }
}