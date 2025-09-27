using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.ContactTypes.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.ContactTypes.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, IContactTypeService contactTypes, IContactTypeCache cache)
	: ServiceAction<IUpdateContactTypeDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await contactTypes.Select(Dto.CreatePrimaryKey(Dto.Id))) as ContactType ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ContactType>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await contactTypes.Select(Dto.CreatePrimaryKey(Dto.Id))) as ContactType;
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, contactTypes, entity.Id);
	}
}
