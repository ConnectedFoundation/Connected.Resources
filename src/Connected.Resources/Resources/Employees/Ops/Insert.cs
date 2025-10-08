using Connected.Entities;
using Connected.Notifications;
using Connected.Resources.Resources.Employees;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Resources.Employees.Ops;
internal sealed class Insert(IStorageProvider storage, IEventService events, IEmployeeService employees, IEmployeeCache cache)
	: ServiceAction<IInsertEmployeeDto>
{
	protected override async Task OnInvoke()
	{
		var entity = await storage.Open<Employee>().Update(Dto.AsEntity<Employee>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, employees, entity.Id);
	}
}
