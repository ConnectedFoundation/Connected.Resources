using Connected.Services;

namespace Connected.Resources.Resources.Effort.Dtos;

public interface IQueryEffortDto : IDto
{
	int TimeSheet { get; set; }
	int? Resource { get; set; }
	DateTimeOffset? Date { get; set; }
	long? WorkItem { get; set; }
}
