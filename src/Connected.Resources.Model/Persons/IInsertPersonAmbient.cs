using Connected.Resources.Persons.Dtos;
using Connected.Services;

namespace Connected.Resources.Persons;
public interface IInsertPersonAmbient
	: IAmbientProvider<IInsertPersonDto>
{
	string Token { get; set; }
}
