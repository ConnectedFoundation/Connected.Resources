using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Resources.Employees;

[Table(Schema = SchemaAttribute.ResourcesSchema)]
internal sealed record Employee : ConsistentEntity<int>, IEmployee
{
	[PrimaryKey(false)]
	public override int Id { get => base.Id; init => base.Id = value; }

	[Ordinal(0)]
	public int? JobPosition { get; init; }

	[Ordinal(1)]
	public int? OrganizationUnit { get; init; }

	[Ordinal(2)]
	public int? CostCenter { get; init; }

	[Ordinal(3)]
	public int? Parent { get; init; }

	[Ordinal(4)]
	public int? EmploymentType { get; init; }
}
