using Connected.Resources.Effort.Dtos;
using Connected.Resources.Effort.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Effort;

internal sealed class EffortService(IServiceProvider services) : Service(services), IEffortService
{
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<long> Insert(IInsertEffortDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IEffort>> Query(IQueryEffortDto dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IEffort?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateEffortDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
