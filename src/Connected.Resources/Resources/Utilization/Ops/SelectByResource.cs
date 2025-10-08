using Connected.Entities;
using Connected.Resources.Resources.Utilization;
using Connected.Resources.Resources.Utilization.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Utilization.Ops;

internal sealed class SelectByResource(IStorageProvider storage, IResourceUtilizationCache cache)
	: ServiceFunction<ISelectResourceUtilizationDto, IResourceUtilization?>
{
	protected override async Task<IResourceUtilization?> OnInvoke()
	{
		return await cache.Get(f => f.Resource == Dto.Resource && f.Date.Date == Dto.Date.Date, async (f) =>
		{
			return await storage.Open<ResourceUtilization>().AsEntity(f => f.Resource == Dto.Resource && f.Date.Date == Dto.Date);
		});

	}
}
