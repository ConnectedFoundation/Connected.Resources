using Connected.Annotations;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.NamedResources;

[Service, ServiceUrl(ResourcesTypesUrls.NamedResources)]
public interface INamedResourceService
{
	Task<ImmutableList<INamedResource>> Lookup(IPrimaryKeyListDto<int> dto);
	Task<INamedResource?> Select(IPrimaryKeyDto<int> dto);
}
