using Connected.Annotations;

namespace Connected.Resources.Resources.Effort.Dtos;

internal sealed class UpdateEffortDto : EffortDto, IUpdateEffortDto
{
	[MinValue(1)]
	public long Id { get; set; }
}
