using Connected.Entities;
using Connected.Resources.Resources.Persons;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Persons.Ops;
internal sealed class Lookup(IPersonCache cache)
	: ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<IPerson>>
{
	protected override async Task<IImmutableList<IPerson>> OnInvoke()
	{
		return await cache.AsEntities(f => Dto.Items.Any(g => g == f.Id));
	}
}
