using Connected.Annotations;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Employees;

[Service, ServiceUrl(ResourcesUrls.Employees)]
public interface IEmployeeService
{
	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Insert(IInsertEmployeeDto dto);

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task Update(IUpdateEmployeeDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IEmployee>> Query(IQueryDto? dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ResourcesUrls.LookupOperation)]
	Task<IImmutableList<IEmployee>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IEmployee?> Select(IPrimaryKeyDto<int> dto);
}
