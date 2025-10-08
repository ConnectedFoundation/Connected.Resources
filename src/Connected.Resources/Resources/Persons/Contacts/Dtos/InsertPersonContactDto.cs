using Connected.Annotations;

namespace Connected.Resources.Resources.Persons.Contacts.Dtos;
internal sealed class InsertPersonContactDto : PersonContactDto, IInsertPersonContactDto
{
	[MinValue(1)]
	public int Head { get; set; }
}
