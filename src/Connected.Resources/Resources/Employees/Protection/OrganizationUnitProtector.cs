using Connected.Common.Types.OrganizationUnits;
using Connected.Entities;
using Connected.Entities.Protection;

namespace Connected.Resources.Resources.Employees.Protection;
internal sealed class OrganizationUnitProtector(IEmployeeCache cache)
	: EntityProtector<IOrganizationUnit>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => f.OrganizationUnit == Entity.Id) != null)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IEmployee)})");
	}
}
