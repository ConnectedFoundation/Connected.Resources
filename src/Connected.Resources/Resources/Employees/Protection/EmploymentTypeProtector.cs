using Connected.Entities;
using Connected.Entities.Protection;
using Connected.Resources.Resources.Employees;
using Connected.Resources.Types.EmploymentTypes;

namespace Connected.Resources.Resources.Employees.Protection;
internal sealed class EmploymentTypeProtector(IEmployeeCache cache)
	: EntityProtector<IEmploymentType>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => f.EmploymentType == Entity.Id) is not null)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IEmployee)})");
	}
}
