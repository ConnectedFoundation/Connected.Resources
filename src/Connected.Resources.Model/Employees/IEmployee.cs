using Connected.Resources.Persons;

namespace Connected.Resources.Employees;
public interface IEmployee : IPerson
{
	int? JobPosition { get; init; }
	int? Department { get; init; }
	int? CostPlace { get; init; }
	int? Parent { get; init; }
	int? EmploymentType { get; init; }
}
