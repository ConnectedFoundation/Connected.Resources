using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.Employees;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Delete(IStorageProvider storage, IEventService events, IEmployeeService employees, IEmployeeCache cache)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await employees.Select(Dto)) as Employee ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Employee>().Update(Dto.AsEntity<Employee>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, employees, Dto.Id);
	}
}
