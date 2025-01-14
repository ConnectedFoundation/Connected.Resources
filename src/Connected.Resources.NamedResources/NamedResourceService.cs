using Connected.Resources.NamedResources.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.NamedResources;
internal sealed class NamedResourceService(IServiceProvider services) : Service(services), INamedResourceService
{
	public async Task<ImmutableList<INamedResource>> Lookup(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<INamedResource?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}
}
