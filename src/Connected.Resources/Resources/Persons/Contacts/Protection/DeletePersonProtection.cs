using Connected.Entities.Protection;
using Connected.Resources.Resources.Persons;
using Connected.Resources.Resources.Persons.Contacts;
using Connected.Services;

namespace Connected.Resources.Resources.Persons.Contacts.Protection;
internal sealed class DeletePersonProtection(IPersonContactService contacts)
	: EntityProtector<IPerson>
{
	protected override async Task OnInvoke()
	{
		if (State != Entities.State.Delete)
			return;

		if ((await contacts.Query(Dto.Factory.CreateHead(Entity.Id))).Count > 0)
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(IPersonContact)}");
	}
}
