
using Connected.Annotations;

namespace Connected.Resources.TimeSheets.Items.Dtos;
internal sealed class InsertTimeSheetItemDto : TimeSheetItemDto, IInsertTimeSheetItemDto
{
	[MinValue(1)]
	public int TimeSheet { get; set; }

	public TimeSheetItemType Type { get; set; } = TimeSheetItemType.Available;
}
