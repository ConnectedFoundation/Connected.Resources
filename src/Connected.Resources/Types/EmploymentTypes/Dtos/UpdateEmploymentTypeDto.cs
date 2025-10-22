using Connected.Annotations;

namespace Connected.Resources.Types.EmploymentTypes.Dtos;

internal sealed class UpdateEmploymentTypeDto : EmploymentTypeDto, IUpdateEmploymentTypeDto
{
	[MinValue(1)]
	public int Id { get; set; }
}
