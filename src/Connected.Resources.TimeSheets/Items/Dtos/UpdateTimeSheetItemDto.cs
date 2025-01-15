
using Connected.Annotations;

namespace Connected.Resources.TimeSheets.Items.Dtos;
internal sealed class UpdateTimeSheetItemDto : TimeSheetItemDto, IUpdateTimeSheetItemDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
