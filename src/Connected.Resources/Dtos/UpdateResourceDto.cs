using Connected.Annotations;

namespace Connected.Resources.Dtos;
internal sealed class UpdateResourceDto : ResourceDto, IUpdateResourceDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
