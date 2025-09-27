using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.ContactTypes.Ops;
internal sealed class Lookup(IContactTypeCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IContactType>>
{
	protected override async Task<IImmutableList<IContactType>> OnInvoke()
	{
		return await cache.AsEntities(f => Dto.Items.Any(g => g == f.Id));
	}
}
