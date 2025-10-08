using Connected.Services;

namespace Connected.Resources.Resources.TimeSheets.Items.Dtos;
public interface ITimeSheetItemDto : IDto
{
	DateTimeOffset Start { get; set; }
	DateTimeOffset? End { get; set; }
}
