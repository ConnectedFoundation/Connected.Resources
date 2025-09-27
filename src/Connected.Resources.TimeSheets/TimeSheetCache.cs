using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.TimeSheets;
internal sealed class TimeSheetCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<ITimeSheet, TimeSheet, int>(cache, storage, ResourcesMetaData.TimeSheetKey), ITimeSheetCache
{
}