using Connected.Entities;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.EmploymentTypes.Ops;
internal sealed class Lookup(IEmploymentTypeCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IEmploymentType>>
{
	protected override async Task<IImmutableList<IEmploymentType>> OnInvoke()
	{
		return await cache.AsEntities(f => Dto.Items.Any(g => g == f.Id));
	}
}
