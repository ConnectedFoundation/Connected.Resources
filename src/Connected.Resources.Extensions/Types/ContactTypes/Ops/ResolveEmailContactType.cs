using Connected.Resources.Types.ContactTypes;
using Connected.Services;

namespace Connected.Resources.ContactTypes.Ops;
internal sealed class ResolveEmailContactType(IContactTypeService types)
	: ServiceFunction<IDto, int?>
{
	protected override async Task<int?> OnInvoke()
	{
		var items = await types.Query(QueryDto.NoPaging);

		if (items.FirstOrDefault(f => string.Equals(f.Name, ResourcesConfiguration.EmailContactType, StringComparison.OrdinalIgnoreCase)) is IContactType type)
			return type.Id;

		return null;
	}
}
