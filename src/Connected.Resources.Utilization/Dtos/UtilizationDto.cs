using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.Utilization.Dtos;

internal abstract class UtilizationDto : Dto, IUtilizationDto
{
	[MinValue(0)]
	public double Capacity { get; set; }

	[MinValue(0)]
	public double Utilization { get; set; }

	[MinValue(0)]
	public double PlannedEffort { get; set; }

	[MinValue(0)]
	public double UnplannedEffort { get; set; }
}
