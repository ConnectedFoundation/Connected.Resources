using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Persons.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Persons.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, IPersonService persons, IPersonCache cache)
	: ServiceAction<IUpdatePersonDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await persons.Select(Dto.CreatePrimaryKey(Dto.Id))) as Person ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Person>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await persons.Select(Dto.CreatePrimaryKey(Dto.Id))) as Person;
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, persons, entity.Id);
	}
}
