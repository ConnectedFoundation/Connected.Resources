using Connected.Entities;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.EmploymentTypes.Ops;
internal sealed class Query(IEmploymentTypeCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IEmploymentType>>
{
	protected override async Task<IImmutableList<IEmploymentType>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}
