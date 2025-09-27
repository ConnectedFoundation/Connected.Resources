using Connected.Entities;
using Connected.Entities.Protection;
using Connected.Resources.JobPositions;

namespace Connected.Resources.Employees.Protection;
internal sealed class JobPositionProtector(IEmployeeCache cache)
	: EntityProtector<IJobPosition>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => f.JobPosition == Entity.Id) is not null)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IEmployee)})");
	}
}
