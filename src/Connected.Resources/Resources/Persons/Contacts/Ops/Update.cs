using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.Persons.Contacts.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Persons.Contacts.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, IPersonContactService contacts)
	: ServiceAction<IUpdatePersonContactDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await contacts.Select(Dto.CreatePrimaryKey(Dto.Id))) as PersonContact ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<PersonContact>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			return SetState(await contacts.Select(Dto.CreatePrimaryKey(Dto.Id))) as PersonContact;
		}, Caller);

		await events.Updated(this, contacts, entity.Id);
	}
}
