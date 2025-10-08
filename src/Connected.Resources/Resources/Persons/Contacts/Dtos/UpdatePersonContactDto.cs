using Connected.Annotations;

namespace Connected.Resources.Resources.Persons.Contacts.Dtos;
internal sealed class UpdatePersonContactDto : PersonContactDto, IUpdatePersonContactDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
