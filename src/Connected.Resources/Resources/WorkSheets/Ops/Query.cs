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
			(Dto.TimeSheet == null || f.TimeSheet == Dto.TimeSheet)
			&& (Dto.Resource == null || f.Resource == Dto.Resource)
			&& (Dto.Start == null || f.Start >= Dto.Start)
			&& (Dto.End == null || f.End <= Dto.End)
			&& (Dto.Type == null || f.Type == Dto.Type)
			&& (Dto.Tags == null || f.Tags != null && f.Tags.Contains(Dto.Tags)));
	}
}
