using Connected.Annotations;
using Connected.Resources.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources;

[Service, ServiceUrl(ResourceUrls.Resources)]
public interface IResourceService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertResourceDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateResourceDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<IResource?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IResource>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get | ServiceOperationVerbs.Post)]
	Task<ImmutableList<IResource>> Lookup(IPrimaryKeyListDto<int> dto);
}
