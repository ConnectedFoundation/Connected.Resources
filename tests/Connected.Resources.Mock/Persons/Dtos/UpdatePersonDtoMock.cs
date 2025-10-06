using Connected.Resources.Persons.Dtos;

namespace Connected.Resources.Mock.Persons.Dtos;
public class UpdatePersonDtoMock
	: PersonDtoMock, IUpdatePersonDto
{
	public int Id { get; set; }
}
