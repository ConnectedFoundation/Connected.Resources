using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Resources.Types.EmploymentTypes.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Types.EmploymentTypes.Ops;
internal sealed class Update(IStorageProvider storage, IEmploymentTypeService employmentTypes, IEventService events, IEmploymentTypeCache cache)
	: ServiceAction<IUpdateEmploymentTypeDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await employmentTypes.Select(Dto.CreatePrimaryKey(Dto.Id))) as EmploymentType ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<EmploymentType>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await employmentTypes.Select(Dto.CreatePrimaryKey(Dto.Id))) as EmploymentType;
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, employmentTypes, entity.Id);
	}
}
