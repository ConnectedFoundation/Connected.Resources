using Connected.Resources.Resources.Persons.Contacts.Dtos;
using Connected.Resources.Types.ContactTypes;
using Connected.Services;
using Connected.Services.Validation;

namespace Connected.Resources.Resources.Persons.Contacts.Validation;
internal sealed class UpdatePersonContactValidation(IContactTypeService contactTypes)
	: Validator<IUpdatePersonContactDto>
{
	protected override async Task OnInvoke()
	{
		if (await contactTypes.Select(Dto.CreatePrimaryKey(Dto.Type)) is null)
			throw ValidationExceptions.NotFound(nameof(IContactType), Dto.Type);
	}
}
