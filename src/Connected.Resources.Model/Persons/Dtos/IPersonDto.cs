using Connected.Services;

namespace Connected.Resources.Persons.Dtos;
public interface IPersonDto : IDto
{
	string? Code { get; set; }
	string? FirstName { get; set; }
	string? LastName { get; set; }

}
