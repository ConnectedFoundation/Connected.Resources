using Connected.Resources.Resources.TimeSheets.Items;
using Connected.Services;

namespace Connected.Resources.Resources.WorkSheets.Dtos;

internal sealed class QueryWorkSheetItemsDto : Dto, IQueryWorkSheetItemsDto
{
	public int? TimeSheet { get; set; }
	public int? Resource { get; set; }
	public DateTimeOffset? Start { get; set; }
	public DateTimeOffset? End { get; set; }
	public TimeSheetItemType? Type { get; set; }
	public string? Tags { get; set; }
}
