using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Persons.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Persons.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IPersonService persons, IPersonCache cache, IInsertPersonAmbient ambient)
	: ServiceFunction<IInsertPersonDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<Person>().Update(Dto.AsEntity<Person>(State.Add, ambient)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, persons, entity.Id);

		return entity.Id;
	}
}
