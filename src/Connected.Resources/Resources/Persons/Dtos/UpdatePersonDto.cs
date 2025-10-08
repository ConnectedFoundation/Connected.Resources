using Connected.Annotations;

namespace Connected.Resources.Resources.Persons.Dtos;
internal sealed class UpdatePersonDto : PersonDto, IUpdatePersonDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
