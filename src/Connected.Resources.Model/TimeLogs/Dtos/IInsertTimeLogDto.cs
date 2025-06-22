using Connected.Services;

namespace Connected.Resources.TimeLogs.Dtos;
public interface IInsertTimeLogDto : IDto
{
	int Resource { get; set; }
	DateTimeOffset Start { get; set; }
	DateTimeOffset? End { get; set; }
	string Type { get; set; }
}
