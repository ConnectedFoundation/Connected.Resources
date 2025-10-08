using Connected.Annotations.Entities;
using Connected.Resources.Documents.WorkItems;

namespace Connected.Resources.Documents;

public static class ResourcesDocumentsMetaData
{
	public const string WorkItemKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IWorkItem)}";
}
