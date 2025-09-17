using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Contacts;

[EntityKey(ResourcesTypesMetaData.ContactKey)]
public interface IContact : IEntity<int>
{
	string Name { get; init; }
	Status Status { get; init; }
}
