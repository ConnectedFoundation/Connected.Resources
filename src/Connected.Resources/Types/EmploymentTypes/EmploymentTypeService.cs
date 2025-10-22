using Connected.Resources.Types.EmploymentTypes.Dtos;
using Connected.Resources.Types.EmploymentTypes.Dtos;
using Connected.Resources.Types.EmploymentTypes.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Types.EmploymentTypes;
internal sealed class EmploymentTypeService(IServiceProvider services) : Service(services), IEmploymentTypeService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertEmploymentTypeDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IEmploymentType>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

    public async Task<IImmutableList<IEmploymentType>> Query(IPrimaryKeyListDto<int> dto)
    {
        return await Invoke(GetOperation<Lookup>(), dto);
    }

    public async Task<IEmploymentType?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateEmploymentTypeDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}
