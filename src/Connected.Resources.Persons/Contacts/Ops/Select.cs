using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Resources.Persons.Contacts.Ops;
internal sealed class Select(IStorageProvider storage)
	: ServiceFunction<IPrimaryKeyDto<int>, IPersonContact?>
{
	protected override async Task<IPersonContact?> OnInvoke()
	{
		return await storage.Open<PersonContact>().AsEntity(f => f.Id == Dto.Id);
	}
}
