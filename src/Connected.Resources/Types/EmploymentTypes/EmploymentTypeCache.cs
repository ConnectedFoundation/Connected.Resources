using Connected.Caching;
using Connected.Resources.Types;
using Connected.Storage;

namespace Connected.Resources.Types.EmploymentTypes;
internal sealed class EmploymentTypeCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<IEmploymentType, EmploymentType, int>(cache, storage, ResourcesTypesMetaData.ResourceKey), IEmploymentTypeCache
{
}
