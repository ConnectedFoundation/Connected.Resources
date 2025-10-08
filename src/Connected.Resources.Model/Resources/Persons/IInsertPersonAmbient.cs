using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.Persons;
public interface IInsertPersonAmbient
	: IAmbientProvider<IInsertPersonDto>
{
	string Token { get; set; }
}
