using Connected.Entities;
using Connected.Entities.Protection;
using Connected.Resources.Persons;

namespace Connected.Resources.Employees.Protection;
internal sealed class PersonProtector(IEmployeeCache cache)
	: EntityProtector<IPerson>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => f.Id == Entity.Id) is not null)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IEmployee)})");
	}
}
