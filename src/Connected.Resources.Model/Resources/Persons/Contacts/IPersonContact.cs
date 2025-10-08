using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Resources.Persons.Contacts;

[EntityKey(ResourcesMetaData.PersonContactKey)]
public interface IPersonContact : IEntity<int>
{
	int Head { get; init; }
	int Type { get; init; }
	string? Value { get; init; }
}
