using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Update(IStorageProvider storage, IEventService events, IEmployeeService employees, IEmployeeCache cache)
	: ServiceAction<IUpdateEmployeeDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await employees.Select(Dto.CreatePrimaryKey(Dto.Id))) as Employee ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Employee>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await employees.Select(Dto.CreatePrimaryKey(Dto.Id))) as Employee;
		}, Caller);

		await cache.Refresh(entity.Id);
		await events.Updated(this, employees, entity.Id);
	}
}
