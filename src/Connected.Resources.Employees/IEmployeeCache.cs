using Connected.Caching;

namespace Connected.Resources.Employees;
internal interface IEmployeeCache
	: IEntityCache<IEmployee, int>
{
}
