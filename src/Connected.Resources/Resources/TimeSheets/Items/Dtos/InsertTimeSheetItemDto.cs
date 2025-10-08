using Connected.Annotations;
using Connected.Resources.Resources.TimeSheets.Items;

namespace Connected.Resources.Resources.TimeSheets.Items.Dtos;
internal sealed class InsertTimeSheetItemDto : TimeSheetItemDto, IInsertTimeSheetItemDto
{
	[MinValue(1)]
	public int TimeSheet { get; set; }

	public TimeSheetItemType Type { get; set; } = TimeSheetItemType.Available;
}
