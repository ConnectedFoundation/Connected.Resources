using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.WorkItems.Ops;

internal sealed class QueryChildren(IStorageProvider storage) : ServiceFunction<IHeadDto<long>, IImmutableList<IWorkItem>>
{
	protected override async Task<IImmutableList<IWorkItem>> OnInvoke()
	{
		return await storage.Open<WorkItem>().AsEntities<IWorkItem>(f => f.Parent == Dto.Head);
	}
}
