﻿using Connected.Resources.TimeLogs.Dtos;
using Connected.Resources.TimeLogs.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeLogs;
internal sealed class TimeLogService(IServiceProvider services)
	: Service(services), ITimeLogService
{
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<long> Insert(IInsertTimeLogDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<ImmutableList<ITimeLog>> Query(IQueryTimeLogsDto dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<ITimeLog?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateTimeLogDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
