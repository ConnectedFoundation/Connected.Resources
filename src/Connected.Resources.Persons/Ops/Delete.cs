using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Persons.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, IPersonService persons, IPersonCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await persons.Select(Dto)) as Person ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Person>().Update(Dto.AsEntity<Person>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, persons, Dto.Id);
	}
}
