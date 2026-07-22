using Connected.Resources.Types.ContactTypes;
using Connected.Services;

namespace Connected.Resources.ContactTypes.Ops;

internal sealed class ResolvePhoneNumberContactType(IContactTypeService types)
    : ServiceFunction<IDto, int?>
{
    protected override async Task<int?> OnInvoke()
    {
        var items = await types.Query(QueryDto.NoPaging);

        if(items.FirstOrDefault(x => string.Equals(x.Name, ResourcesConfiguration.PhoneNumberContactType, StringComparison.OrdinalIgnoreCase)) is IContactType type)
            return type.Id;

        return null;
    }
}
