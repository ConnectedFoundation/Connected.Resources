using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.JobPositions.Ops;
internal sealed class Select(IJobPositionCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IJobPosition?>
{
	protected override async Task<IJobPosition?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
