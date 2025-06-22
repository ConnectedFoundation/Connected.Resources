using Connected.Annotations.Entities;
using Connected.Resources.WorkItems;

namespace Connected.Resources;

public static class ResourcesDocumentsMetaData
{
	public const string WorkItemKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IWorkItem)}";
}
