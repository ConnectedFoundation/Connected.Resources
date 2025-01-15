using Connected.Caching;

namespace Connected.Resources.WorkItems;

internal sealed class WorkItemCache(ICachingService cachingService)
	: CacheContainer<WorkItem, long>(cachingService, ResourcesMetaData.WorkItemKey), IWorkItemCache
{
}
