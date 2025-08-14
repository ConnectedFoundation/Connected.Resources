using Connected.Annotations;
using Connected.Resources.TimeLogs.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.TimeLogs;

[Service, ServiceUrl(ResourcesUrls.TimeLogs)]
public interface ITimeLogService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertTimeLogDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTimeLogDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Get)]
	Task<IImmutableList<ITimeLog>> Query(IQueryTimeLogsDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post | ServiceOperationVerbs.Get)]
	Task<ITimeLog?> Select(IPrimaryKeyDto<long> dto);
}
