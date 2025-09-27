using Connected.Services;

namespace Connected.Resources.Employees.Dtos;
public interface IEmployeeDto : IPrimaryKeyDto<int>
{
	int? JobPosition { get; set; }
	int? OrganizationUnit { get; set; }
	int? CostCenter { get; set; }
	int? Parent { get; set; }
	int? EmploymentType { get; set; }
}
