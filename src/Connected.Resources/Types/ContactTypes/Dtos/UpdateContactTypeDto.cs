using Connected.Annotations;

namespace Connected.Resources.Types.ContactTypes.Dtos;
internal sealed class UpdateContactTypeDto : ContactTypeDto, IUpdateContactTypeDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
