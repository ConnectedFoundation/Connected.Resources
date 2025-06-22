using Connected.Annotations;

namespace Connected.Resources.Utilization.Dtos;

internal sealed class InsertResourceUtilizationDto : ResourceUtilizationDto, IInsertResourceUtilizationDto
{
	[NonDefault]
	public DateTimeOffset Date { get; set; }

	[MinValue(1)]
	public int Resource { get; set; }
}
