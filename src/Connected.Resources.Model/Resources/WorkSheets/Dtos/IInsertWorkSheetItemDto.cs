namespace Connected.Resources.Resources.WorkSheets.Dtos;

public interface IInsertWorkSheetItemDto : IWorkSheetItemDto
{
	int TimeSheet { get; set; }
	int Resource { get; set; }
}
