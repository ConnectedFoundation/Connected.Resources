using Connected.Resources.NamedResources.Dtos;
using Connected.Resources.Types.NamedResources;
using System.Collections.Immutable;

namespace Connected.Resources.NamedResources;
public abstract class NamedResourceProvider : Middleware, INamedResourceProvider
{
	protected INamedResourceProviderDto Dto { get; private set; } = default!;
	public async Task<ImmutableList<INamedResource>> Invoke(INamedResourceProviderDto dto)
	{
		Dto = dto;

		return await OnInvoke();
	}

	protected virtual async Task<ImmutableList<INamedResource>> OnInvoke()
	{
		return await Task.FromResult<ImmutableList<INamedResource>>([]);
	}
}
