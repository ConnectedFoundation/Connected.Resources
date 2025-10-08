using Connected.Annotations;

namespace Connected.Resources.Resources.WorkSheets.Dtos;

internal sealed class UpdateWorkSheetItemDto : WorkSheetItemDto, IUpdateWorkSheetItemDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
