using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.Persons.Contacts;
using Connected.Resources.Resources.Persons.Contacts.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Persons.Contacts.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IPersonContactService contacts)
	: ServiceFunction<IInsertPersonContactDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<PersonContact>().Update(Dto.AsEntity<PersonContact>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, contacts, entity.Id);

		return entity.Id;
	}
}
