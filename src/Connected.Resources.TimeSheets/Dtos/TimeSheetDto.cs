using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.TimeSheets.Dtos;
internal abstract class TimeSheetDto : Dto, ITimeSheetDto
{
	[Required, MaxLength(128)]
	public required string Name { get; set; }

	public bool IsDefault { get; set; }
}
