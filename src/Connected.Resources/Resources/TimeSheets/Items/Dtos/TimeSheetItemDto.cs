using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.Resources.TimeSheets.Items.Dtos;
internal abstract class TimeSheetItemDto : Dto, ITimeSheetItemDto
{
	[NonDefault]
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset? End { get; set; }
}
