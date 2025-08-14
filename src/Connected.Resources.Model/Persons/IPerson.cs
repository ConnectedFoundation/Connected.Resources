using Connected.Entities;

namespace Connected.Resources.Persons;
public interface IPerson : IEntity<int>
{
	string? Code { get; init; }
	string? FirstName { get; init; }
	string? LastName { get; init; }
}
