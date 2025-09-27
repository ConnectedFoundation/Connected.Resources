using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Persons.Contacts.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, IPersonContactService contacts)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await contacts.Select(Dto)) as PersonContact ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<PersonContact>().Update(Dto.AsEntity<PersonContact>(State.Delete));
		await events.Deleted(this, contacts, Dto.Id);
	}
}
