using Connected.Resources.ContactTypes;
using Connected.Resources.Persons.Contacts.Dtos;
using Connected.Services;
using Connected.Validation;

namespace Connected.Resources.Persons.Contacts.Validation;
internal sealed class InsertPersonCOntactValidator(IContactTypeService contactTypes)
	: Validator<IInsertPersonContactDto>
{
	protected override async Task OnInvoke()
	{
		if (await contactTypes.Select(Dto.CreatePrimaryKey(Dto.Type)) is null)
			throw ValidationExceptions.NotFound(nameof(IContactType), Dto.Type);
	}
}
