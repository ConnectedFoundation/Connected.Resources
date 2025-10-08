using Connected.Entities;
using Connected.Resources.Resources.WorkSheets.Dtos;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.WorkSheets.Ops;

internal sealed class Query(IStorageProvider storage)
	: ServiceFunction<IQueryWorkSheetItemsDto, IImmutableList<IWorkSheetItem>>
{
	protected override async Task<IImmutableList<IWorkSheetItem>> OnInvoke()
	{
		return await storage.Open<WorkSheetItem>().AsEntities<IWorkSheetItem>(f =>
			(Dto.TimeSheet is null || f.TimeSheet == Dto.TimeSheet)
			&& (Dto.Resource is null || f.Resource == Dto.Resource)
			&& (Dto.Start is null || f.Start >= Dto.Start)
			&& (Dto.End is null || f.End <= Dto.End)
			&& (Dto.Type is null || f.Type == Dto.Type)
			&& (Dto.Tags is null || f.Tags is not null && f.Tags.Contains(Dto.Tags)));
	}
}
