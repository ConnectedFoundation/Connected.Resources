using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.Persons;
internal sealed class InsertPersonAmbient
	: AmbientProvider<IInsertPersonDto>, IInsertPersonAmbient
{
	[Required, MaxLength(Services.Dto.DefaultNameLength)]
	public required string Token { get; set; } = Guid.NewGuid().ToString();
}
