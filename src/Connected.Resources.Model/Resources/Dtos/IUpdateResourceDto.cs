using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Resources.Dtos;
public interface IUpdateResourceDto : IPrimaryKeyDto<int>
{
	string Token { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
	string? Type { get; set; }
	ResourceBehavior Behavior { get; set; }
	float? HourlyRate { get; set; }
	int? JobPosition { get; set; }
}
