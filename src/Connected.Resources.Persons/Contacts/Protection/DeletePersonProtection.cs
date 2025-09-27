using Connected.Entities.Protection;
using Connected.Services;

namespace Connected.Resources.Persons.Contacts.Protection;
internal sealed class DeletePersonProtection(IPersonContactService contacts)
	: EntityProtector<IPerson>
{
	protected override async Task OnInvoke()
	{
		if ((await contacts.Query(Dto.Factory.CreateHead(Entity.Id))).Count > 0)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IPersonContact)}");
	}
}
