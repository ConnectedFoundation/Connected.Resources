using Connected.Annotations;

namespace Connected.Resources.Resources.Effort.Dtos;

internal sealed class InsertEffortDto : EffortDto, IInsertEffortDto
{
	[MinValue(1)]
	public int Resource { get; set; }

	public long? WorkItem { get; set; }

	[MinValue(1)]
	public int TimeSheet { get; set; }
}
