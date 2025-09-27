using Connected.Annotations.Entities;
using Connected.Resources.ContactTypes;
using Connected.Resources.EmploymentTypes;
using Connected.Resources.JobPositions;

namespace Connected.Resources;
public static class ResourcesTypesMetaData
{
	public const string ResourceKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IResource)}";
	public const string JobPositionKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IJobPosition)}";
	public const string ContactTypeKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IContactType)}";
	public const string EmploymentTypeKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IEmploymentType)}";
}
