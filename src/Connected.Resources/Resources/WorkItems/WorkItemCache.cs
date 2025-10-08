using Connected.Caching;
using Connected.Resources.Documents;

namespace Connected.Resources.Resources.WorkItems;

internal sealed class WorkItemCache(ICachingService cachingService)
	: CacheContainer<WorkItem, long>(cachingService, ResourcesDocumentsMetaData.WorkItemKey), IWorkItemCache
{
}
