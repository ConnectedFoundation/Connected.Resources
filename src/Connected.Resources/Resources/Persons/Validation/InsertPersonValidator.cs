using Connected.Entities;
using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services.Validation;

namespace Connected.Resources.Resources.Persons.Validation;
internal sealed class InsertPersonValidator(IPersonCache cache)
	: Validator<IInsertPersonDto>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => string.Equals(f.Code, Dto.Code, StringComparison.OrdinalIgnoreCase)) is not null)
			throw ValidationExceptions.ValueExists(nameof(IPerson.Code), Dto.Code);
	}
}
