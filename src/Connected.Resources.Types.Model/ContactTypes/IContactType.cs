using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.ContactTypes;

[EntityKey(ResourcesTypesMetaData.ContactTypeKey)]
public interface IContactType : IEntity<int>
{
	string Name { get; init; }
	Status Status { get; init; }
}
