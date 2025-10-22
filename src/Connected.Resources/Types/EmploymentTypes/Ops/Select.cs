using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Types.EmploymentTypes.Ops;
internal sealed class Select(IEmploymentTypeCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IEmploymentType?>
{
	protected override async Task<IEmploymentType?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
