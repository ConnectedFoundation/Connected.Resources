using Connected.Services;

namespace Connected.Resources.Resources.TimeSheets.Dtos;
public interface ITimeSheetDto : IDto
{
	string Name { get; set; }
	bool IsDefault { get; set; }
}
