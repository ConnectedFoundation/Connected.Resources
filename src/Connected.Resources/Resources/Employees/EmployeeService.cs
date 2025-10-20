using Connected.Resources.Resources.Employees.Dtos;
using Connected.Resources.Resources.Employees.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Employees;
internal sealed class EmployeeService(IServiceProvider services)
		: Service(services), IEmployeeService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task Insert(IInsertEmployeeDto dto)
	{
		await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IEmployee>> Query(IQueryEmployeesDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? new QueryEmployeesDto());
	}

	public async Task<IImmutableList<IEmployee>> Query(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IEmployee?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateEmployeeDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
