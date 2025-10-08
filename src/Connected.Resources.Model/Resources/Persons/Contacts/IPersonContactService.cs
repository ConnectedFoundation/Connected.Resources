using Connected.Annotations;
using Connected.Resources.Resources.Persons.Contacts.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Persons.Contacts;

[Service, ServiceUrl(ResourcesUrls.PersonContacts)]
public interface IPersonContactService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertPersonContactDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdatePersonContactDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IPersonContact>> Query(IHeadDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IPersonContact>> Query(IHeadListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IPersonContact?> Select(IPrimaryKeyDto<int> dto);
}
