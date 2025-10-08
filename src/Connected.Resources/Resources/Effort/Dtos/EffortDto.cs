using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.Effort.Dtos;

internal abstract class EffortDto : Dto, IEffortDto
{
	[NonDefault]
	public DateTimeOffset Date { get; set; }

	[MaxLength(1024)]
	public string? Description { get; set; }

	[MaxLength(1024)]
	public string? Tags { get; set; }

	[MinValue(0)]
	public double Value { get; set; }
}
