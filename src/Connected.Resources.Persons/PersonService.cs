using Connected.Resources.Persons.Dtos;
using Connected.Resources.Persons.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Persons;
internal sealed class PersonService(IServiceProvider services)
		: Service(services), IPersonService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertPersonDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IPerson>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IImmutableList<IPerson>> Query(IPrimaryKeyListDto<int> dto)
	{
		return await Invoke(GetOperation<Lookup>(), dto);
	}

	public async Task<IPerson?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task<IPerson?> Select(IValueDto<string> dto)
	{
		return await Invoke(GetOperation<SelectByCode>(), dto);
	}

	public async Task Update(IUpdatePersonDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
