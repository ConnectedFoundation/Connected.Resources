using Connected.Annotations;
using Connected.Resources.Resources.TimeSheets.Items;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.WorkSheets.Dtos;

internal abstract class WorkSheetItemDto : Dto, IWorkSheetItemDto
{
	[NonDefault]
	public DateTimeOffset Start { get; set; }
	public DateTimeOffset? End { get; set; }
	public TimeSheetItemType Type { get; set; } = TimeSheetItemType.Available;

	[MaxLength(1024)]
	public string? Tags { get; set; }
}
