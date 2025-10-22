using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Resources.Types.EmploymentTypes.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Types.EmploymentTypes.Ops;
internal sealed class Insert(IStorageProvider storage, IEmploymentTypeService employmentTypes, IEventService events, IEmploymentTypeCache cache)
	: ServiceFunction<IInsertEmploymentTypeDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<EmploymentType>().Update(Dto.AsEntity<EmploymentType>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, employmentTypes, entity.Id);

		return entity.Id;
	}
}
