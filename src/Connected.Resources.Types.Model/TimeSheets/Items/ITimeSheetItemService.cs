using Connected.Annotations;
using Connected.Resources.TimeSheets.Items.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeSheets.Items;

[Service, ServiceUrl(ResourceUrls.TimeSheetItems)]
public interface ITimeSheetItemService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertTimeSheetItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTimeSheetItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Get)]
	Task<ITimeSheetItem?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Get)]
	Task<ImmutableList<ITimeSheetItem>> Query(IQueryDto? dto);
}
