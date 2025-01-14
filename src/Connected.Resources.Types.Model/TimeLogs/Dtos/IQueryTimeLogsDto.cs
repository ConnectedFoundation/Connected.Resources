using Connected.Services;

namespace Connected.Resources.TimeLogs.Dtos;
public interface IQueryTimeLogsDto : IDto
{
	DateTimeOffset? Start { get; set; }
	DateTimeOffset? End { get; set; }
	int? Resource { get; set; }
	string? Type { get; set; }
}
