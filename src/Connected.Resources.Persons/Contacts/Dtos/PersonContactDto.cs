using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Persons.Contacts.Dtos;
internal abstract class PersonContactDto : Dto, IPersonContactDto
{
	[MinValue(1)]
	public int Type { get; set; }

	[MaxLength(256)]
	public string? Value { get; set; }
}
