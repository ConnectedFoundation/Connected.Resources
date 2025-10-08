using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Ops;
internal sealed class Delete(IStorageProvider storage, IResourceService resources, IEventService events, IResourceCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await resources.Select(Dto)) as Resource ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Resource>().Update(Dto.AsEntity<Resource>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, resources, Dto.Id);
	}
}
