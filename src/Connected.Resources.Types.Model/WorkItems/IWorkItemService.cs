using Connected.Annotations;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.WorkItems;

[Service, ServiceUrl(ResourceUrls.WorkItems)]
public interface IWorkItemService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertWorkItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateWorkItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IWorkItem?> Select(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IImmutableList<IWorkItem>> Query(IQueryWorkItemsDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IImmutableList<IWorkItem>> Query(IHeadDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<long> dto);
}
