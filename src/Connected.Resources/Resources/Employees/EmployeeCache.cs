using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.Resources.Employees;
internal sealed class EmployeeCache(ICachingService cache, IStorageProvider storage)
		: EntityCache<IEmployee, Employee, int>(cache, storage, ResourcesMetaData.EmployeeKey), IEmployeeCache
{
}
