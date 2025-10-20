using Connected.Entities;
using Connected.Identities;
using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services;
using Connected.Services.Validation;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.Persons.Validation;
internal sealed class UpdatePersonValidator(IPersonCache cache, IUserService users)
	: Validator<IUpdatePersonDto>
{
	protected override async Task OnInvoke()
	{
		if (await cache.AsEntity(f => string.Equals(f.Code, Dto.Code, StringComparison.OrdinalIgnoreCase) && f.Id != Dto.Id) is not null)
			throw ValidationExceptions.ValueExists(nameof(IPerson.Code), Dto.Code);

		if (Dto.User is not null)
		{
			if (await users.Select(Dto.CreatePrimaryKey(Dto.User.GetValueOrDefault())) is null)
				throw ValidationExceptions.NotFound(nameof(IPerson.User), Dto.User);

			if (await cache.AsEntity(f => f.User == Dto.User.GetValueOrDefault()) is IPerson person && person.Id != Dto.Id)
				throw new ValidationException($"Another person is already associated with the user '{Dto.User}'.");
		}
	}
}
