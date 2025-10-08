using Connected.Caching;
using Connected.Resources.Types;
using Connected.Storage;

namespace Connected.Resources.Types.JobPositions;
internal sealed class JobPositionCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<IJobPosition, JobPosition, int>(cache, storage, ResourcesTypesMetaData.ResourceKey), IJobPositionCache
{
}
