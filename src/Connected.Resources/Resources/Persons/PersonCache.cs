using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.Resources.Persons;
internal sealed class PersonCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IPerson, Person, int>(cache, storage, ResourcesMetaData.PersonKey), IPersonCache
{
}
