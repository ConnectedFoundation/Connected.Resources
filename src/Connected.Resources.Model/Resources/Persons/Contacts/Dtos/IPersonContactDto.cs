using Connected.Services;

namespace Connected.Resources.Resources.Persons.Contacts.Dtos;
public interface IPersonContactDto : IDto
{
	int Type { get; set; }
	string? Value { get; set; }

}
