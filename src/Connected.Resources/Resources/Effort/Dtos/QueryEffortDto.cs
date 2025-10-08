using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.Resources.Effort.Dtos;

internal sealed class QueryEffortDto : Dto, IQueryEffortDto
{
	[MinValue(1)]
	public int TimeSheet { get; set; }

	public int? Resource { get; set; }

	public DateTimeOffset? Date { get; set; }

	public long? WorkItem { get; set; }
}
