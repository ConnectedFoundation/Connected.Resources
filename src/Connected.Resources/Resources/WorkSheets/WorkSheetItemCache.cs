using Connected.Caching;

namespace Connected.Resources.Resources.WorkSheets;

internal sealed class WorkSheetItemCache(ICachingService cachingService)
	: CacheContainer<WorkSheetItem, int>(cachingService, ResourcesMetaData.WorkSheetItemKey), IWorkSheetItemCache
{
}
