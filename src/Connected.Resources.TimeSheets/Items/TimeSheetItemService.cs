using Connected.Resources.TimeSheets.Items.Dtos;
using Connected.Resources.TimeSheets.Items.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeSheets.Items;
internal sealed class TimeSheetItemService(IServiceProvider services)
	: Service(services), ITimeSheetItemService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertTimeSheetItemDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<ImmutableList<ITimeSheetItem>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<ITimeSheetItem>> Query(IQueryTimeSheetItemsDto dto)
	{
		return await Invoke(GetOperation<QueryByDate>(), dto);
	}

	public async Task<ITimeSheetItem?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateTimeSheetItemDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
