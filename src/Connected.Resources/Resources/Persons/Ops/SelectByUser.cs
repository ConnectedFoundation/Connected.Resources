using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Resources.Persons.Ops;
internal sealed class SelectByUser(IPersonCache cache)
	: ServiceFunction<IValueDto<long>, IPerson?>
{
	protected override async Task<IPerson?> OnInvoke()
	{
		return await cache.AsEntity(f => f.User == Dto.Value);
	}
}
