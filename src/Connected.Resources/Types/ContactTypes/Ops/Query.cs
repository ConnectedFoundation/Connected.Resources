using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.ContactTypes.Ops;
internal sealed class Query(IContactTypeCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IContactType>>
{
	protected override async Task<IImmutableList<IContactType>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}
