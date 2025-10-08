using Connected.Resources.NamedResources.Dtos;
using Connected.Resources.Types.NamedResources;
using System.Collections.Immutable;

namespace Connected.Resources.NamedResources;
public interface INamedResourceProvider : IMiddleware
{
	Task<ImmutableList<INamedResource>> Invoke(INamedResourceProviderDto dto);
}
