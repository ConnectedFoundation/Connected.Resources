using Connected.Caching;

namespace Connected.Resources.Resources.Effort;

internal sealed class EffortCache(ICachingService cachingService)
	: CacheContainer<Effort, long>(cachingService, ResourcesMetaData.EffortKey), IEffortCache
{
}
