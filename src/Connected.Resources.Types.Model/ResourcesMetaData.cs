using Connected.Annotations.Entities;
using Connected.Resources.JobPositions;
using Connected.Resources.TimeLogs;

namespace Connected.Resources;
public static class ResourcesMetaData
{
	public const string ResourceKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IResource)}";
	public const string JobPositionKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IJobPosition)}";
	public const string TimeLogKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeLog)}";
}
