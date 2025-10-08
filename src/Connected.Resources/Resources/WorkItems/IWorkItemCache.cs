using Connected.Caching;

namespace Connected.Resources.Resources.WorkItems;
internal interface IWorkItemCache : ICacheContainer<WorkItem, long>
{
}
