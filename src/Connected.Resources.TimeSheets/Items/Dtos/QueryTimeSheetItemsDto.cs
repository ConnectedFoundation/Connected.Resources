using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.TimeSheets.Items.Dtos;

internal sealed class QueryTimeSheetItemsDto : Dto, IQueryTimeSheetItemsDto
{
	[NonDefault]
	public DateTimeOffset Date { get; set; }

	[MinValue(1)]
	public int TimeSheet { get; set; }
}
