using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.ContactTypes.Ops;
internal sealed class Select(IContactTypeCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IContactType?>
{
	protected override async Task<IContactType?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
