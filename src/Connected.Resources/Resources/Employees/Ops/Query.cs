using Connected.Entities;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Query(IEmployeeCache cache)
	: ServiceFunction<IQueryEmployeesDto, IImmutableList<IEmployee>>
{
	protected override async Task<IImmutableList<IEmployee>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities(f => Dto.OrganizationUnits is null
			|| (f.OrganizationUnit is not null && Dto.OrganizationUnits.Any(g => g == f.OrganizationUnit.GetValueOrDefault())));
	}
}
