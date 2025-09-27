using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Persons.Contacts.Ops;
internal sealed class Lookup(IStorageProvider storage)
	: ServiceFunction<IHeadListDto<int>, IImmutableList<IPersonContact>>
{
	protected override async Task<IImmutableList<IPersonContact>> OnInvoke()
	{
		return await storage.Open<PersonContact>().AsEntities<IPersonContact>(f => Dto.Items.Any(g => g == f.Head));
	}
}
