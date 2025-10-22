using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Types.EmploymentTypes.Ops;
internal sealed class Delete(IStorageProvider storage, IEmploymentTypeService employmentTypes, IEventService events, IEmploymentTypeCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await employmentTypes.Select(Dto)) as EmploymentType ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<EmploymentType>().Update(Dto.AsEntity<EmploymentType>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, employmentTypes, Dto.Id);
	}
}