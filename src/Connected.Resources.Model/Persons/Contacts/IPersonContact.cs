using Connected.Entities;

namespace Connected.Resources.Persons.Contacts;
public interface IPersonContact : IEntity<int>
{
	int Head { get; init; }
	int Contact { get; init; }
	string Value { get; init; }
}
