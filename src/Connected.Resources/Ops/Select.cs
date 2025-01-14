using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Ops;
internal sealed class Select(IResourceCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IResource?>
{
	protected override async Task<IResource?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
