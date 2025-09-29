using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Identities;

namespace Connected.Resources.Persons;

[EntityKey(ResourcesMetaData.PersonKey)]
public interface IPerson : IEntity<int>, IIdentity
{
	string? Code { get; init; }
	string? FirstName { get; init; }
	string? LastName { get; init; }
	Status Status { get; init; }
}
