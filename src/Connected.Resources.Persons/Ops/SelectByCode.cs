using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.Persons.Ops;
internal sealed class SelectByCode(IPersonCache cache)
	: ServiceFunction<IValueDto<string>, IPerson?>
{
	protected override async Task<IPerson?> OnInvoke()
	{
		return await cache.AsEntity(f => string.Equals(f.Code, Dto.Value, StringComparison.OrdinalIgnoreCase));
	}
}
