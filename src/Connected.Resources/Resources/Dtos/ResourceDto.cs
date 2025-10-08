using Connected.Annotations;
using Connected.Entities;
using Connected.Resources.Resources;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.Dtos;
internal abstract class ResourceDto : Dto
{
	[Required, MaxLength(128)]
	public required string Token { get; set; }

	[Required, MaxLength(128)]
	public required string Code { get; set; }

	public Status Status { get; set; } = Status.Disabled;

	[MaxLength(128)]
	public string? Type { get; set; }

	public ResourceBehavior Behavior { get; set; } = ResourceBehavior.Singleton;

	[MinValue(0)]
	public float? HourlyRate { get; set; }

	public int? JobPosition { get; set; }
}
