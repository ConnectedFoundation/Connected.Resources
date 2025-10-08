using Connected.Annotations;
using Connected.Resources.Types.EmploymentTypes.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.EmploymentTypes;

[Service, ServiceUrl(ResourcesTypesUrls.EmploymentTypes)]
public interface IEmploymentTypeService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task<int> Insert(IInsertEmploymentTypeDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateEmploymentTypeDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IEmploymentType>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesTypesUrls.LookupOperation)]
	Task<IImmutableList<IEmploymentType>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IEmploymentType?> Select(IPrimaryKeyDto<int> dto);
}
