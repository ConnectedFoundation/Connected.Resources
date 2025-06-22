using Connected.Annotations.Entities;
using Connected.Resources.JobPositions;

namespace Connected.Resources;
public static class ResourcesTypesMetaData
{
	public const string ResourceKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IResource)}";
	public const string JobPositionKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IJobPosition)}";
}
