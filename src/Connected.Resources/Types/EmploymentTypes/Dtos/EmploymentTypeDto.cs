using Connected.Annotations;
using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Types.EmploymentTypes.Dtos;
internal abstract class EmploymentTypeDto : Dto, IEmploymentTypeDto
{
	[Required, MaxLength(128)]
	public required string Code { get; set; }

	[Required, MaxLength(128)]
	public required string Name { get; set; }

	public Status Status { get; set; } = Status.Disabled;
}