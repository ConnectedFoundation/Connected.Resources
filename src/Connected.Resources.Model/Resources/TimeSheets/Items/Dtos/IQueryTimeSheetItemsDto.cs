using Connected.Services;

namespace Connected.Resources.Resources.TimeSheets.Items.Dtos;

public interface IQueryTimeSheetItemsDto : IDto
{
	DateTimeOffset Date { get; set; }
	int TimeSheet { get; set; }
}
