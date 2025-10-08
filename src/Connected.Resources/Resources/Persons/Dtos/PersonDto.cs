using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.Persons.Dtos;
internal abstract class PersonDto : Dto, IPersonDto
{
	[MaxLength(DefaultCodeLength)]
	public string? Code { get; set; }

	[MaxLength(DefaultNameLength)]
	public string? FirstName { get; set; }

	[MaxLength(DefaultNameLength)]
	public string? LastName { get; set; }

	public Status Status { get; set; } = Status.Disabled;
}
