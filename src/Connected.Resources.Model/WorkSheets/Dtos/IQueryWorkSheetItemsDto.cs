using Connected.Resources.TimeSheets.Items;
using Connected.Services;

namespace Connected.Resources.WorkSheets.Dtos;

public interface IQueryWorkSheetItemsDto : IDto
{
	int? TimeSheet { get; set; }
	int? Resource { get; set; }
	DateTimeOffset? Start { get; set; }
	DateTimeOffset? End { get; set; }
	TimeSheetItemType? Type { get; set; }
	string? Tags { get; set; }
}
