using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.JobPositions;
internal sealed class JobPositionCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<JobPosition, int>(cache, storage, ResourcesTypesMetaData.ResourceKey), IJobPositionCache
{
}
