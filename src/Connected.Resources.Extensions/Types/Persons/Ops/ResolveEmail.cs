using Connected.Resources.ContactTypes;
using Connected.Resources.Persons.Dtos;
using Connected.Resources.Resources.Persons.Contacts;
using Connected.Services;

namespace Connected.Resources.Persons.Ops;
internal sealed class ResolveEmail(IPersonContactService contacts, IContactTypeExtensions contactTypes)
	: ServiceFunction<IResolveEmailDto, string?>
{
	protected override async Task<string?> OnInvoke()
	{
		if (await contactTypes.ResolveEmailContactType() is not int id)
			return null;

		var items = await contacts.Query(Dto.CreateHead(Dto.Person));
		var entity = items.FirstOrDefault(f => f.Id == id);

		if (entity is null)
			return null;

		return entity.Value;
	}
}
