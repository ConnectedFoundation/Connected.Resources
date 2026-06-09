using Connected.Entities;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.WorkItems.Ops;
internal sealed class Query(IStorageProvider storage)
	: ServiceFunction<IQueryWorkItemsDto, IImmutableList<IWorkItem>>
{
	protected override async Task<IImmutableList<IWorkItem>> OnInvoke()
	{
		return await storage.Open<WorkItem>().AsEntities<IWorkItem>(f => f.TimeSheet == Dto.TimeSheet
			&& (Dto.Entity == null || string.Equals(f.Entity, Dto.Entity, StringComparison.OrdinalIgnoreCase))
			&& (Dto.EntityId == null || string.Equals(f.EntityId, Dto.EntityId, StringComparison.OrdinalIgnoreCase))
			&& (Dto.Start == null || f.Start >= Dto.Start)
			&& (Dto.End == null || f.End <= Dto.End)
			&& (Dto.Resource == null || f.Resource == Dto.Resource)
			&& (Dto.Parent == null || f.Parent == Dto.Parent));
	}
}
