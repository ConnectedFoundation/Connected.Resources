using Connected.Services;

namespace Connected.Resources.TimeSheets.Items.Dtos;

public interface IQueryTimeSheetItemsDto : IDto
{
	DateTimeOffset Date { get; set; }
	int TimeSheet { get; set; }
}
