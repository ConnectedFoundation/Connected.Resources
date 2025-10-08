using Connected.Annotations;
using Connected.Resources.Documents;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Documents.WorkItems;

[Service, ServiceUrl(ResourcesDocumentsUrls.WorkItems)]
public interface IWorkItemService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertWorkItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateWorkItemDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IWorkItem?> Select(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IWorkItem>> Query(IQueryWorkItemsDto dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesDocumentsUrls.QueryChildrenOperation)]
	Task<IImmutableList<IWorkItem>> Query(IHeadDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesDocumentsUrls.QueryInDateOperation)]
	Task<IImmutableList<IWorkItem>> Query(IQueryWorkItemsInDateDto dto);

	[ServiceOperation(ServiceOperationVerbs.Patch)]
	Task Patch(IPatchDto<long> dto);
}
