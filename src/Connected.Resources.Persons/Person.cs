using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Persons;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record Person : ConsistentEntity<int>, IPerson
{
	[Ordinal(0), Length(Dto.DefaultCodeLength), Index(true)]
	public string? Code { get; init; }

	[Ordinal(1), Length(Dto.DefaultNameLength)]
	public string? FirstName { get; init; }

	[Ordinal(2), Length(Dto.DefaultNameLength)]
	public string? LastName { get; init; }

	[Ordinal(3), Length(Dto.DefaultCodeLength), Index(true)]
	public required string Token { get; init; }

	[Ordinal(4)]
	public Status Status { get; init; }
}
