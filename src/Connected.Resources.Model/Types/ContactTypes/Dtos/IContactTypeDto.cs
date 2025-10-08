using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Types.ContactTypes.Dtos;
public interface IContactTypeDto : IDto
{
	string Name { get; set; }
	Status Status { get; set; }
}
