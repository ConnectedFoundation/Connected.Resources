using Connected.Services;

namespace Connected.Resources.Utilization.Dtos;

public interface IUtilizationDto : IDto
{
	double Capacity { get; set; }
	double Utilization { get; set; }
	double PlannedEffort { get; set; }
	double UnplannedEffort { get; set; }
}
