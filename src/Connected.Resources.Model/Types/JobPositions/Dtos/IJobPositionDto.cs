using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Types.JobPositions.Dtos;
public interface IJobPositionDto : IDto
{
	string Code { get; set; }
	string Name { get; set; }
	Status Status { get; set; }
	float? HourlyRate { get; set; }
}
