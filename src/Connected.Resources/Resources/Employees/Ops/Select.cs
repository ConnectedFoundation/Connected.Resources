using Connected.Entities;
using Connected.Resources.Resources.Employees;
using Connected.Services;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Select(IEmployeeCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IEmployee?>
{
	protected override async Task<IEmployee?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
