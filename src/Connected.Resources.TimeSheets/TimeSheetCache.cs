using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.TimeSheets;
internal sealed class TimeSheetCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<TimeSheet, int>(cache, storage, ResourcesMetaData.TimeSheetKey), ITimeSheetCache
{
}
