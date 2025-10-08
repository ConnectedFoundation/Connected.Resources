using Connected.Resources.Resources.Utilization.Dtos;
using Connected.Resources.Resources.Utilization.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Utilization;

internal sealed class ResourceUtilizationService(IServiceProvider services)
	: Service(services), IResourceUtilizationService
{
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<DeleteResource>(), dto);
	}

	public Task<long> Insert(IInsertResourceUtilizationDto dto)
	{
		return Invoke(GetOperation<InsertResource>(), dto);
	}

	public async Task Patch(IPatchDto<long> dto)
	{
		await Invoke(GetOperation<PatchResource>(), dto);
	}

	public async Task<IImmutableList<IResourceUtilization>> Query(IPrimaryKeyListDto<long> dto)
	{
		return await Invoke(GetOperation<QueryResources>(), dto);
	}

	public async Task<IResourceUtilization?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<SelectResource>(), dto);
	}

	public async Task<IResourceUtilization?> Select(ISelectResourceUtilizationDto dto)
	{
		return await Invoke(GetOperation<SelectByResource>(), dto);
	}

	public async Task Update(IUpdateResourceUtilizationDto dto)
	{
		await Invoke(GetOperation<UpdateResource>(), dto);
	}
}
