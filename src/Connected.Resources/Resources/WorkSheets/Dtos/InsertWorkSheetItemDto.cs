using Connected.Annotations;

namespace Connected.Resources.Resources.WorkSheets.Dtos;

internal sealed class InsertWorkSheetItemDto : WorkSheetItemDto, IInsertWorkSheetItemDto
{
	[MinValue(1)]
	public int TimeSheet { get; set; }

	[MinValue(1)]
	public int Resource { get; set; }
}
