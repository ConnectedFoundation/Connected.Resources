using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Ops;
internal sealed class Query(IResourceCache cache)
	: ServiceFunction<IQueryDto, ImmutableList<IResource>>
{
	protected override async Task<ImmutableList<IResource>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities<IResource>();
	}
}
