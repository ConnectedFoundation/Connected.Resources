using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Persons.Contacts;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record PersonContact : ConsistentEntity<int>, IPersonContact
{
	[Ordinal(0)]
	public int Head { get; init; }

	[Ordinal(1)]
	public int Type { get; init; }

	[Ordinal(2), Length(256)]
	public string? Value { get; init; }
}
