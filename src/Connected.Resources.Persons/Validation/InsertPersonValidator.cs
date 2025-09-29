using Connected.Entities;
using Connected.Resources.Persons.Dtos;
using Connected.Validation;

namespace Connected.Resources.Persons.Validation;
internal sealed class InsertPersonValidator(IPersonCache cache)
	: Validator<IInsertPersonDto>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => string.Equals(f.Code, Dto.Code, StringComparison.OrdinalIgnoreCase)) is not null)
			throw ValidationExceptions.ValueExists(nameof(IPerson.Code), Dto.Code);
	}
}
