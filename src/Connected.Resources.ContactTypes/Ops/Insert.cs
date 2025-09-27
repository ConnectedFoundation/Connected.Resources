using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.ContactTypes.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.ContactTypes.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IContactTypeService contactTypes, IContactTypeCache cache)
	: ServiceFunction<IInsertContactTypeDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<ContactType>().Update(Dto.AsEntity<ContactType>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, contactTypes, entity.Id);

		return entity.Id;
	}
}
