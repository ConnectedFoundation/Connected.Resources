using Connected.Entities;
using Connected.Entities.Protection;

namespace Connected.Resources.Employees.Protection;
internal sealed class EmployeeProtector(IEmployeeCache cache)
	: EntityProtector<IEmployee>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => f.Parent == Entity.Id) is not null)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IEmployee)})");
	}
}
