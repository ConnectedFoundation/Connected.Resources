using Connected.Services;

namespace Connected.Resources.TimeLogs.Dtos;
public interface IUpdateTimeLogDto : IPrimaryKeyDto<long>
{
	DateTimeOffset Start { get; set; }
	DateTimeOffset? End { get; set; }
	string Type { get; set; }
}
