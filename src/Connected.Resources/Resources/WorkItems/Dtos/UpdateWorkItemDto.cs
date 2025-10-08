using Connected.Annotations;
using Connected.Resources.Documents.WorkItems.Dtos;

namespace Connected.Resources.Resources.WorkItems.Dtos;
internal sealed class UpdateWorkItemDto : WorkItemDto, IUpdateWorkItemDto
{
	[MinValue(1)]
	public long Id { get; set; }
}
