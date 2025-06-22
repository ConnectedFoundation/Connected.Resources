using Connected.Annotations;
using Connected.Resources.Utilization.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Utilization;

[Service, ServiceUrl(ResourcesUrls.ResourceUtilization)]
public interface IResourceUtilizationService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertResourceUtilizationDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateResourceUtilizationDto dto);

	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IResourceUtilization?> Select(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesUrls.SelectByResourceOperation)]
	Task<IResourceUtilization?> Select(ISelectResourceUtilizationDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IResourceUtilization>> Query(IPrimaryKeyListDto<long> dto);
}
