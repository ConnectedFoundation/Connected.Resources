using Connected.Resources.ContactTypes.Dtos;
using Connected.Resources.ContactTypes.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.ContactTypes;
internal sealed class ContactTypeService(IServiceProvider services)
		: Service(services), IContactTypeService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertContactTypeDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IContactType>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<IContactType>> Query(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IContactType?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateContactTypeDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
