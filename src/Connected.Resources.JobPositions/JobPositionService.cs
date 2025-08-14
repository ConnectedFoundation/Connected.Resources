using Connected.Resources.JobPositions.Dtos;
using Connected.Resources.JobPositions.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.JobPositions;
internal sealed class JobPositionService(IServiceProvider services) : Service(services), IJobPositionService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertJobPositionDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IJobPosition>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IJobPosition?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateJobPositionDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
