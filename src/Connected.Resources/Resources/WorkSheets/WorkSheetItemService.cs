using Connected.Resources.Resources.WorkSheets.Dtos;
using Connected.Resources.Resources.WorkSheets.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.WorkSheets;

internal sealed class WorkSheetItemService(IServiceProvider services)
	: Service(services), IWorkSheetItemService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertWorkSheetItemDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IWorkSheetItem>> Query(IQueryWorkSheetItemsDto dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IWorkSheetItem?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateWorkSheetItemDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
