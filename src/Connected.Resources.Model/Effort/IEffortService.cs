using Connected.Annotations;
using Connected.Resources.Effort.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Effort;

[Service, ServiceUrl(ResourcesUrls.Effort)]
public interface IEffortService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertEffortDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateEffortDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IEffort?> Select(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IEffort>> Query(IQueryEffortDto dto);
}
