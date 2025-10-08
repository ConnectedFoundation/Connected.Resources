using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Ops;
internal sealed class Query(IResourceCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IResource>>
{
	protected override async Task<IImmutableList<IResource>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}
