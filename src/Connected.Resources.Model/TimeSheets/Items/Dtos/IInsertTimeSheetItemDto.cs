namespace Connected.Resources.TimeSheets.Items.Dtos;
public interface IInsertTimeSheetItemDto : ITimeSheetItemDto
{
	int TimeSheet { get; set; }
	TimeSheetItemType Type { get; set; }
}
