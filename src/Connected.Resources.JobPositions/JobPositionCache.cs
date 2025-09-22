using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.JobPositions;
internal sealed class JobPositionCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<IJobPosition, JobPosition, int>(cache, storage, ResourcesTypesMetaData.ResourceKey), IJobPositionCache
{
}
