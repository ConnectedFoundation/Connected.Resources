using Connected.Services;

namespace Connected.Resources.TimeSheets.Dtos;
public interface ITimeSheetDto : IDto
{
	string Name { get; set; }
	bool IsDefault { get; set; }
}
