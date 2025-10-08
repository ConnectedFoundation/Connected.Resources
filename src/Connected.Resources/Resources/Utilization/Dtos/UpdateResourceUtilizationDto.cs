using Connected.Annotations;

namespace Connected.Resources.Resources.Utilization.Dtos;

internal sealed class UpdateResourceUtilizationDto : ResourceUtilizationDto, IUpdateResourceUtilizationDto
{
	[MinValue(1)]
	public long Id { get; set; }
}
