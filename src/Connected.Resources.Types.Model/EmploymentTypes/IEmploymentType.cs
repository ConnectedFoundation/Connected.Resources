using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.EmploymentTypes;

[EntityKey(ResourcesTypesMetaData.EmploymentTypeKey)]
public interface IEmploymentType : IEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
}
