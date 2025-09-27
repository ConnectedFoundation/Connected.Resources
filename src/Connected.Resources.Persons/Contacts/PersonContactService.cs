using Connected.Resources.Persons.Contacts.Dtos;
using Connected.Resources.Persons.Contacts.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Persons.Contacts;

internal sealed class PersonContactService(IServiceProvider services)
		: Service(services), IPersonContactService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertPersonContactDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IPersonContact>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<IImmutableList<IPersonContact>> Query(IHeadListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IPersonContact?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdatePersonContactDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
