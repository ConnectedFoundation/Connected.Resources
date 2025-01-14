using Connected.Annotations;
using Connected.Resources.JobPositions.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.JobPositions;

[Service, ServiceUrl(ResourceUrls.JobPositions)]
public interface IJobPositionService
{
	Task<int> Insert(IInsertJobPositionDto dto);
	Task Update(IUpdateJobPositionDto dto);
	Task Delete(IPrimaryKeyDto<int> dto);
	Task<IJobPosition?> Select(IPrimaryKeyDto<int> dto);
	Task<ImmutableList<IJobPosition>> Query(IQueryDto? dto);
}
