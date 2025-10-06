using Connected.Core.Services.Mock;
using Connected.Entities;
using Connected.Resources.Persons.Dtos;

namespace Connected.Resources.Mock.Persons.Dtos;
public class PersonDtoMock
	: DtoMock, IPersonDto
{
	public string? Code { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public Status Status { get; set; }
}
