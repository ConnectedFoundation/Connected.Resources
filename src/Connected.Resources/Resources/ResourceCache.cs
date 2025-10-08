using Connected.Caching;
using Connected.Resources.Types;
using Connected.Storage;

namespace Connected.Resources.Resources;
internal sealed class ResourceCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<IResource, Resource, int>(cache, storage, ResourcesTypesMetaData.ResourceKey), IResourceCache
{
}
