using Connected.Annotations;
using Connected.Services;

namespace Connected.Resources.Resources.Employees.Dtos;
internal abstract class EmployeeDto : Dto, IEmployeeDto
{
	public int? JobPosition { get; set; }
	public int? OrganizationUnit { get; set; }
	public int? CostCenter { get; set; }
	public int? Parent { get; set; }
	public int? EmploymentType { get; set; }

	[MinValue(1)]
	public int Id { get; set; }
}
