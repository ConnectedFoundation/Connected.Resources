using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.ContactTypes;
internal sealed class ContactTypeCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IContactType, ContactType, int>(cache, storage, ResourcesTypesMetaData.ContactTypeKey), IContactTypeCache
{
}
