using Connected.Annotations.Entities;
using Connected.Resources.Resources;
using Connected.Resources.Types.ContactTypes;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Resources.Types.JobPositions;

namespace Connected.Resources.Types;
public static class ResourcesTypesMetaData
{
	public const string ResourceKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IResource)}";
	public const string JobPositionKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IJobPosition)}";
	public const string ContactTypeKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IContactType)}";
	public const string EmploymentTypeKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IEmploymentType)}";
}
