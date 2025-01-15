using Connected.Annotations;

namespace Connected.Resources.WorkItems.Dtos;
internal sealed class UpdateWorkItemDto : WorkItemDto, IUpdateWorkItemDto
{
	[MinValue(1)]
	public long Id { get; set; }
}
