using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Dtos;
public interface IInsertResourceDto : IDto
{
	string Token { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
	string? Type { get; set; }
	ResourceBehavior Behavior { get; set; }
	float? HourlyRate { get; set; }
	int? JobPosition { get; set; }
}
