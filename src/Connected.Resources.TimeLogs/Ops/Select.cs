using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.TimeLogs.Ops;
internal sealed class Select(IStorageProvider storage, ITimeLogCache cache)
	: ServiceFunction<IPrimaryKeyDto<long>, ITimeLog?>
{
	protected override async Task<ITimeLog?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<TimeLog>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}
