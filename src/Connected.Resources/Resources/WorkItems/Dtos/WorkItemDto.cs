using Connected.Annotations;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.WorkItems.Dtos;
internal abstract class WorkItemDto : EntityDto, IWorkItemDto
{
	public DateTimeOffset? Start { get; set; }
	public DateTimeOffset? End { get; set; }
	public int? Resource { get; set; }

	[MinValue(1)]
	public int TimeSheet { get; set; }
	public WorkItemStatus Status { get; set; } = WorkItemStatus.Draft;

	[MinValue(0)]
	public double Estimation { get; set; }
	public long? Parent { get; set; }
	public int? JobPosition { get; set; }
}
