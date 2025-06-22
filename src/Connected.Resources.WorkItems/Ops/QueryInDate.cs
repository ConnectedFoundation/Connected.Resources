using Connected.Entities;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.WorkItems.Ops;

internal sealed class QueryIndate(IStorageProvider storage)
	: ServiceFunction<IQueryWorkItemsInDateDto, IImmutableList<IWorkItem>>
{
	protected override async Task<IImmutableList<IWorkItem>> OnInvoke()
	{
		return await storage.Open<WorkItem>().AsEntities<IWorkItem>(f =>
				f.Resource == Dto.Resource
			&& f.TimeSheet == Dto.TimeSheet
			&& f.Start is not null
			&& f.Start <= Dto.Date
			&& f.End is not null
			&& f.End >= Dto.Date);
	}
}
