using Connected.Caching;

namespace Connected.Resources.TimeLogs;
internal interface ITimeLogCache : ICacheContainer<TimeLog, long>
{
}
