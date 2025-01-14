using Connected.Services;

namespace Connected.Resources.TimeLogs.Dtos;
internal sealed class QueryTimeLogsDto : Dto, IQueryTimeLogsDto
{
	public int? Resource { get; set; }
	public DateTimeOffset? Start { get; set; }
	public DateTimeOffset? End { get; set; }
	public string? Type { get; set; }
}
