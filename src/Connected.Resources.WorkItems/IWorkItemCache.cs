using Connected.Caching;

namespace Connected.Resources.WorkItems;
internal interface IWorkItemCache : ICacheContainer<WorkItem, long>
{
}
