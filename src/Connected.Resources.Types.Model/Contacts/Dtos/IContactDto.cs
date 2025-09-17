using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Contacts.Dtos;
public interface IContactDto : IDto
{
	string Name { get; set; }
	Status Status { get; set; }
}
