using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Resources.Types;

namespace Connected.Resources.Types.EmploymentTypes;

[EntityKey(ResourcesTypesMetaData.EmploymentTypeKey)]
public interface IEmploymentType : IEntity<int>
{
	string Name { get; init; }
	string Code { get; init; }
	Status Status { get; init; }
}
