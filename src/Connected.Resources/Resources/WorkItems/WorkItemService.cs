using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Resources.Resources.WorkItems.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.WorkItems;
internal sealed class WorkItemService(IServiceProvider services)
	: Service(services), IWorkItemService
{
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<long> Insert(IInsertWorkItemDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Patch(IPatchDto<long> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task<IImmutableList<IWorkItem>> Query(IQueryWorkItemsDto dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IImmutableList<IWorkItem>> Query(IHeadDto<long> dto)
	{
		return await Invoke(GetOperation<QueryChildren>(), dto);
	}

	public async Task<IImmutableList<IWorkItem>> Query(IQueryWorkItemsInDateDto dto)
	{
		return await Invoke(GetOperation<QueryIndate>(), dto);
	}

	public async Task<IWorkItem?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateWorkItemDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
