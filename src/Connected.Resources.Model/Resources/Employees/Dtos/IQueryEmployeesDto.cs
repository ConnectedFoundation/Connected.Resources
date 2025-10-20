using Connected.Services;

namespace Connected.Resources.Resources.Employees.Dtos;
public interface IQueryEmployeesDto
	: IQueryDto
{
	List<int>? OrganizationUnits { get; set; }
}
