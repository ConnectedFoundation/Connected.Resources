
using Connected.Resources.ContactTypes.Ops;
using Connected.Services;

namespace Connected.Resources.ContactTypes;
internal sealed class ContactTypeExtensions(IServiceProvider services)
		: Service(services), IContactTypeExtensions
{
	public async Task<int?> ResolveEmailContactType()
	{
		return await Invoke(GetOperation<ResolveEmailContactType>(), Dto.Empty);
	}

    public async Task<int?> ResolvePhoneNumberContactType()
    {
        return await Invoke(GetOperation<ResolvePhoneNumberContactType>(), Dto.Empty);
    }
}
