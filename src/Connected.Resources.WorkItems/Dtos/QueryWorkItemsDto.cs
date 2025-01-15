using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.WorkItems.Dtos;
internal sealed class QueryWorkItemsDto : Dto, IQueryWorkItemsDto
{
	[MaxLength(1024)]
	public string? Entity { get; set; }

	[MaxLength(128)]
	public string? EntityId { get; set; }

	public DateTimeOffset? Start { get; set; }

	public DateTimeOffset? End { get; set; }

	public int? Resource { get; set; }

	[MinValue(1)]
	public int TimeSheet { get; set; }

	public long? Parent { get; set; }
}
