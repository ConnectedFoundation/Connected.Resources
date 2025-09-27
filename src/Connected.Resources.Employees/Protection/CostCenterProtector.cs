using Connected.Common.Types.CostCenters;
using Connected.Entities;
using Connected.Entities.Protection;

namespace Connected.Resources.Employees.Protection;
internal sealed class CostCenterProtector(IEmployeeCache cache)
	: EntityProtector<ICostCenter>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => f.CostCenter == Entity.Id) is not null)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IEmployee)})");
	}
}
