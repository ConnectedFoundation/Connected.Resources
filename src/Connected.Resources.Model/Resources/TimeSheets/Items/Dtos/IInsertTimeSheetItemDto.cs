using Connected.Resources.Resources.TimeSheets.Items;

namespace Connected.Resources.Resources.TimeSheets.Items.Dtos;
public interface IInsertTimeSheetItemDto : ITimeSheetItemDto
{
	int TimeSheet { get; set; }
	TimeSheetItemType Type { get; set; }
}
