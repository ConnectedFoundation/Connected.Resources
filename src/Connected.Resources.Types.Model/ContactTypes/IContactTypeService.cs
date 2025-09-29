using Connected.Annotations;
using Connected.Resources.ContactTypes.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.ContactTypes;

[Service, ServiceUrl(ResourcesTypesUrls.ContactTypes)]
public interface IContactTypeService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertContactTypeDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateContactTypeDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IContactType>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ServiceUrlAttribute.Lookup)]
	Task<IImmutableList<IContactType>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IContactType?> Select(IPrimaryKeyDto<int> dto);
}
