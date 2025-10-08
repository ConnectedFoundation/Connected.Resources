using Connected.Caching;

namespace Connected.Resources.Resources.TimeLogs;
internal interface ITimeLogCache : ICacheContainer<TimeLog, long>
{
}
