using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Persons.Ops;
internal sealed class Select(IPersonCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IPerson?>
{
	protected override async Task<IPerson?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}
