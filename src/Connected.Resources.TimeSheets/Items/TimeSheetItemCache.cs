using Connected.Caching;
using Connected.Storage;

namespace Connected.Resources.TimeSheets.Items;
internal sealed class TimeSheetItemCache(ICachingService cache, IStorageProvider storage)
	: EntityCache<TimeSheetItem, int>(cache, storage, ResourcesMetaData.TimeSheetItemKey), ITimeSheetItemCache
{
}
