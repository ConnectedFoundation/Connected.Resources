using Connected.Caching;

namespace Connected.Resources.Utilization;

internal sealed class ResourceUtilizationCache(ICachingService cachingService)
	: CacheContainer<ResourceUtilization, long>(cachingService, ResourcesMetaData.ResourceUtilizationKey), IResourceUtilizationCache
{
}
