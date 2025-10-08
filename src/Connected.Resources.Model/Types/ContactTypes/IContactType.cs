using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Types.ContactTypes;

[EntityKey(ResourcesTypesMetaData.ContactTypeKey)]
public interface IContactType : IEntity<int>
{
	string Name { get; init; }
	Status Status { get; init; }
}
