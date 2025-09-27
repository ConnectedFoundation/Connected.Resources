using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Resources.Persons.Contacts.Ops;
internal sealed class Query(IStorageProvider storage)
	: ServiceFunction<IHeadDto<int>, IImmutableList<IPersonContact>>
{
	protected override async Task<IImmutableList<IPersonContact>> OnInvoke()
	{
		return await storage.Open<PersonContact>().AsEntities<IPersonContact>(f => f.Head == Dto.Head);
	}
}
