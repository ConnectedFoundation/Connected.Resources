using Connected.Resources.Resources.TimeSheets.Items;
using Connected.Services;

namespace Connected.Resources.Resources.WorkSheets.Dtos;

public interface IWorkSheetItemDto : IDto
{
	DateTimeOffset Start { get; set; }
	DateTimeOffset? End { get; set; }
	TimeSheetItemType Type { get; set; }
	string? Tags { get; set; }
}
