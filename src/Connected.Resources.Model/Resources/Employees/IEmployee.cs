using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Resources.Employees;

[EntityKey(ResourcesMetaData.EmployeeKey)]
public interface IEmployee : IEntity<int>
{
	int? JobPosition { get; init; }
	int? OrganizationUnit { get; init; }
	int? CostCenter { get; init; }
	int? Parent { get; init; }
	int? EmploymentType { get; init; }
}
