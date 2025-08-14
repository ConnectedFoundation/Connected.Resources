using Connected.Entities;

namespace Connected.Resources.EmploymentTypes;
public interface IEmploymentType : IEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
}
