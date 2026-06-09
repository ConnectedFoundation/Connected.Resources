using Connected.Entities;
using Connected.Resources.Resources.TimeLogs.Dtos;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.TimeLogs.Ops;
internal sealed class Query(IStorageProvider storage)
	: ServiceFunction<IQueryTimeLogsDto, IImmutableList<ITimeLog>>
{
	protected override async Task<IImmutableList<ITimeLog>> OnInvoke()
	{
		return await storage.Open<TimeLog>().AsEntities<ITimeLog>(f =>
			(Dto.Resource == null || f.Resource == Dto.Resource)
			&& (Dto.Start == null || f.Start >= Dto.Start)
			&& (Dto.End == null || f.End >= Dto.End)
			&& (Dto.Type == null || string.Equals(f.Type, Dto.Type, StringComparison.OrdinalIgnoreCase)));
	}
}
