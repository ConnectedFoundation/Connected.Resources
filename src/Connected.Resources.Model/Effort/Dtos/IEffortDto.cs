using Connected.Services;

namespace Connected.Resources.Effort.Dtos;

public interface IEffortDto : IDto
{
	DateTimeOffset Date { get; set; }
	string? Description { get; set; }
	string? Tags { get; set; }
	double Value { get; set; }
}
