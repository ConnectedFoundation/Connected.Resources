using Connected.Annotations;

namespace Connected.Resources.Resources.TimeSheets.Items.Dtos;
internal sealed class UpdateTimeSheetItemDto : TimeSheetItemDto, IUpdateTimeSheetItemDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
