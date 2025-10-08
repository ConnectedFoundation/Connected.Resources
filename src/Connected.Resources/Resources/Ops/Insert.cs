using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Ops;
internal sealed class Insert(IStorageProvider storage, IResourceService resources, IEventService events, IResourceCache cache)
	: ServiceFunction<IInsertResourceDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<Resource>().Update(Dto.AsEntity<Resource>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, resources, entity.Id);

		return entity.Id;
	}
}
