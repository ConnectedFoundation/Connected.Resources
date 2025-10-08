using Connected.Annotations;
using Connected.Resources.Resources.TimeSheets.Items.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.TimeSheets.Items;

[Service, ServiceUrl(ResourcesUrls.TimeSheetItems)]
public interface ITimeSheetItemService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertTimeSheetItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTimeSheetItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<ITimeSheetItem?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesUrls.QueryByDateOperation)]
	Task<IImmutableList<ITimeSheetItem>> Query(IQueryTimeSheetItemsDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<ITimeSheetItem>> Query(IQueryDto? dto);
}
