using Connected.Entities;
using Connected.Resources.Resources.Employees;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Query(IEmployeeCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IEmployee>>
{
	protected override async Task<IImmutableList<IEmployee>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}
