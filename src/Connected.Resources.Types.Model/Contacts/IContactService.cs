using Connected.Annotations;
using Connected.Resources.Contacts.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Contacts;

[Service, ServiceUrl(ResourcesTypesUrls.Contacts)]
public interface IContactService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertContactDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateContactDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IContact>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ServiceUrlAttribute.Lookup)]
	Task<IImmutableList<IContact>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IContact?> Select(IPrimaryKeyDto<int> dto);
}
