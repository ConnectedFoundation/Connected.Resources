using Connected.Annotations;
using Connected.Resources.Types.JobPositions.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.JobPositions;

[Service, ServiceUrl(ResourcesTypesUrls.JobPositions)]
public interface IJobPositionService
{
	Task<int> Insert(IInsertJobPositionDto dto);
	Task Update(IUpdateJobPositionDto dto);
	Task Delete(IPrimaryKeyDto<int> dto);
	Task<IJobPosition?> Select(IPrimaryKeyDto<int> dto);
	Task<IImmutableList<IJobPosition>> Query(IQueryDto? dto);
}
