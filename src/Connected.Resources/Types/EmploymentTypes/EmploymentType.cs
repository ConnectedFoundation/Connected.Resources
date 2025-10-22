using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Types.EmploymentTypes;
[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record EmploymentType : ConsistentEntity<int>, IEmploymentType
{
	[Ordinal(0), Length(128), Index(true)]
	public required string Code { get; init; }

	[Ordinal(1), Length(128)]
	public required string Name { get; init; }

	[Ordinal(2)]
	public Status Status { get; init; }
}
