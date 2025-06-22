using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Utilization.Ops;

internal sealed class QueryResources(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyListDto<long>, IImmutableList<IResourceUtilization>>
{
	protected override async Task<IImmutableList<IResourceUtilization>> OnInvoke()
	{
		return await storage.Open<ResourceUtilization>().AsEntities<IResourceUtilization>(f => Dto.Items.Any(g => g == f.Id));
	}
}
