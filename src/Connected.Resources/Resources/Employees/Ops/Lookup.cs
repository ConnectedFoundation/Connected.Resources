using Connected.Entities;
using Connected.Resources.Resources.Employees;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Lookup(IEmployeeCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IEmployee>>
{
	protected override async Task<IImmutableList<IEmployee>> OnInvoke()
	{
		return await cache.AsEntities(f => Dto.Items.Any(g => g == f.Id));
	}
}
