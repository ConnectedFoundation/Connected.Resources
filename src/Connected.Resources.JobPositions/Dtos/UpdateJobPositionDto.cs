using Connected.Annotations;

namespace Connected.Resources.JobPositions.Dtos;

internal sealed class UpdateJobPositionDto : JobPositionDto, IUpdateJobPositionDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
