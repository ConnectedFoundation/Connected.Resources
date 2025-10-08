using Connected.Annotations;
using Connected.Resources.Resources.WorkSheets.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.WorkSheets;

[Service, ServiceUrl(ResourcesUrls.WorkSheetItems)]
public interface IWorkSheetItemService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertWorkSheetItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateWorkSheetItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IWorkSheetItem?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IWorkSheetItem>> Query(IQueryWorkSheetItemsDto dto);
}
