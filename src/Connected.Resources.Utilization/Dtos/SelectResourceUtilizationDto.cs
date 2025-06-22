using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.Utilization.Dtos;

internal sealed class SelectResourceUtilizationDto : Dto, ISelectResourceUtilizationDto
{
	[MinValue(1)]
	public int Resource { get; set; }

	[NonDefault]
	public DateTimeOffset Date { get; set; }
}
