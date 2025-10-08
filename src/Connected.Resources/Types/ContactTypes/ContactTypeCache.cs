using Connected.Caching;
using Connected.Resources.Types;
using Connected.Storage;

namespace Connected.Resources.Types.ContactTypes;
internal sealed class ContactTypeCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IContactType, ContactType, int>(cache, storage, ResourcesTypesMetaData.ContactTypeKey), IContactTypeCache
{
}
