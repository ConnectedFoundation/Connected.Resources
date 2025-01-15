using Connected.Services;

namespace Connected.Resources.WorkItems.Dtos;
public interface IWorkItemDto : IDto
{
	DateTimeOffset? Start { get; set; }
	DateTimeOffset? End { get; set; }
	int? Resource { get; set; }
	int TimeSheet { get; set; }
	WorkItemStatus Status { get; set; }
	double Estimation { get; set; }
	long? Parent { get; set; }
	int? JobPosition { get; set; }
}
