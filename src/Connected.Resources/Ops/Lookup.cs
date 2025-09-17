using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Ops;
internal sealed class Lookup(IResourceCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IResource>>
{
	protected override async Task<IImmutableList<IResource>> OnInvoke()
	{
		return await cache.AsEntities<IResource>(f => Dto.Items.Any(g => g == f.Id));
	}
}
