using Connected.Resources.Resources.TimeSheets.Dtos;
using Connected.Resources.Resources.TimeSheets.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.TimeSheets;
internal sealed class TimeSheetService(IServiceProvider services)
	: Service(services), ITimeSheetService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertTimeSheetDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<ITimeSheet>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<ITimeSheet?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateTimeSheetDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
