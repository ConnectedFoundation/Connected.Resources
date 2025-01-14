using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources;
internal sealed class ResourceCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<Resource, int>(cache, storage, ResourcesMetaData.ResourceKey), IResourceCache
{
}
