using Connected.Entities;
using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Persons.Ops;
internal sealed class Query(IPersonCache cache)
	: ServiceFunction<IQueryPersonDto, IImmutableList<IPerson>>
{
	protected override async Task<IImmutableList<IPerson>> OnInvoke()
	{
		var query = cache.AsQueryable();

		if (Dto.Users is { Count: > 0 })
			query = query.Where(x => x.User.HasValue && Dto.Users.Contains(x.User.Value));

		return await query.AsEntities();
	}
}
