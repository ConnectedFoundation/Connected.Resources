using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.ContactTypes.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, IContactTypeService contactTypes, IContactTypeCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await contactTypes.Select(Dto)) as ContactType ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<ContactType>().Update(Dto.AsEntity<ContactType>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, contactTypes, Dto.Id);
	}
}
