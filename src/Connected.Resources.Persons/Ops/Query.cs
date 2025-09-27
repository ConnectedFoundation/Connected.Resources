using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Persons.Ops;
internal sealed class Query(IPersonCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IPerson>>
{
	protected override async Task<IImmutableList<IPerson>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}
