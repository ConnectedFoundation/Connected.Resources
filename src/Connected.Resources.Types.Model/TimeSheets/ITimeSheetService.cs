using Connected.Annotations;
using Connected.Resources.TimeSheets.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeSheets;

[Service, ServiceUrl(ResourceUrls.TimeSheets)]
public interface ITimeSheetService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertTimeSheetDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTimeSheetDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ITimeSheet?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<ITimeSheet>> Query(IQueryDto? dto);
}
