using Connected.Annotations;
using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.JobPositions.Dtos;
internal abstract class JobPositionDto : Dto, IJobPositionDto
{
	[Required, MaxLength(128)]
	public required string Code { get; set; }

	[Required, MaxLength(128)]
	public required string Name { get; set; }

	public Status Status { get; set; } = Status.Disabled;

	[MinValue(0)]
	public float? HourlyRate { get; set; }
}
