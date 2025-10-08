using Connected.Annotations;
using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Persons;

[Service, ServiceUrl(ResourcesUrls.Persons)]
public interface IPersonService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertPersonDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdatePersonDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IPerson>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesUrls.LookupOperation)]
	Task<IImmutableList<IPerson>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IPerson?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesMetaData.SelectByCodeOperation)]
	Task<IPerson?> Select(IValueDto<string> dto);
}
