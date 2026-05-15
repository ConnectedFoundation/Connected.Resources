using Connected.Annotations;
using Connected.Resources.Types.JobPositions.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.JobPositions;

[Service, ServiceUrl(ResourcesTypesUrls.JobPositions)]
public interface IJobPositionService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertJobPositionDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateJobPositionDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IJobPosition?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IJobPosition>> Query(IQueryDto? dto);
}