using Connected.Resources.Resources.Dtos;
using Connected.Resources.Resources.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources;
internal sealed class ResourceService(IServiceProvider services) : Service(services), IResourceService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertResourceDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IResource>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<IResource>> Lookup(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IResource?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateResourceDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
