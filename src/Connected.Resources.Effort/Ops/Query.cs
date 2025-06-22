using Connected.Entities;
using Connected.Resources.Effort.Dtos;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Effort.Ops;

internal sealed class Query(IStorageProvider storage)
  : ServiceFunction<IQueryEffortDto, IImmutableList<IEffort>>
{
	protected override async Task<IImmutableList<IEffort>> OnInvoke()
	{
		return await storage.Open<Effort>().AsEntities<IEffort>(f =>
				f.TimeSheet == Dto.TimeSheet
			&& (Dto.Resource is null || f.Resource == Dto.Resource)
			&& (Dto.Date is null || f.Date == Dto.Date)
			&& (Dto.WorkItem is null || f.WorkItem == Dto.WorkItem));
	}
}
