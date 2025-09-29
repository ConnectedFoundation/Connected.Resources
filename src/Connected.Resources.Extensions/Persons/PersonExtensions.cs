using Connected.Resources.Persons.Dtos;
using Connected.Resources.Persons.Ops;
using Connected.Services;

namespace Connected.Resources.Persons;
internal sealed class PersonExtensions(IServiceProvider services)
		: Service(services), IPersonExtensions
{
	public async Task<string?> ResolveEmail(IResolveEmailDto dto)
	{
		return await Invoke(GetOperation<ResolveEmail>(), dto);
	}
}
