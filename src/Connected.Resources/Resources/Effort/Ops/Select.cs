using Connected.Entities;
using Connected.Resources.Resources.Effort;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Effort.Ops;

internal sealed class Select(IStorageProvider storage, IEffortCache cache)
  : ServiceFunction<IPrimaryKeyDto<long>, IEffort?>
{
	protected override async Task<IEffort?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<Effort>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}
