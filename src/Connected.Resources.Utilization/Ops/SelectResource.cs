using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Utilization.Ops;

internal sealed class SelectResource(IStorageProvider storage, IResourceUtilizationCache cache)
	: ServiceFunction<IPrimaryKeyDto<long>, IResourceUtilization?>
{
	protected override async Task<IResourceUtilization?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<ResourceUtilization>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}
