using Connected.Entities;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Resources.WorkItems;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.WorkItems.Ops;
internal sealed class Select(IStorageProvider storage, IWorkItemCache cache)
	: ServiceFunction<IPrimaryKeyDto<long>, IWorkItem?>
{
	protected override async Task<IWorkItem?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<WorkItem>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}
