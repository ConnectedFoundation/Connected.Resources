using Connected.Services;

namespace Connected.Resources.Resources.Employees.Dtos;
internal sealed class QueryEmployeesDto
	: QueryDto, IQueryEmployeesDto
{
	public List<int>? OrganizationUnits { get; set; }
}
