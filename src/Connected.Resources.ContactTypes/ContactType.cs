
using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.ContactTypes;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record ContactType : ConsistentEntity<int>, IContactType
{
	[Ordinal(0), Length(Dto.DefaultNameLength)]
	public required string Name { get; init; }

	[Ordinal(1)]
	public Status Status { get; init; }
}
