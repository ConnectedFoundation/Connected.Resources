using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.WorkItems.Dtos;

internal sealed class QueryWorkItemsInDateDto : Dto, IQueryWorkItemsInDateDto
{
	[MinValue(1)]
	public int TimeSheet { get; set; }

	[MinValue(1)]
	public int Resource { get; set; }

	[NonDefault]
	public DateTimeOffset Date { get; set; }
}
