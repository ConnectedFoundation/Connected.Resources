using Connected.Caching;

namespace Connected.Resources.Resources.Employees;
internal interface IEmployeeCache
	: IEntityCache<IEmployee, int>
{
}
