using Connected.Resources.NamedResources.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.NamedResources.Ops;
internal sealed class Lookup(IMiddlewareService middlewares, IResourceService resources) : ServiceFunction<IPrimaryKeyListDto<int>, ImmutableList<INamedResource>>
{
	protected override async Task<ImmutableList<INamedResource>> OnInvoke()
	{
		var providers = middlewares.Query<INamedResourceProvider>();
		var dto = CreateDto();
		var result = new List<INamedResource>();

		Task.WaitAll(providers, dto);

		foreach (var provider in providers.Result)
		{
			var namedResources = await provider.Invoke(dto.Result);

			foreach (var namedResource in namedResources)
			{
				result.Add(namedResource);

				var resolved = dto.Result.Items.FirstOrDefault(f => f.Id == namedResource.Id);

				if (resolved is not null)
					dto.Result.Items.Remove(resolved);
			}

			if (dto.Result.Items.Count == 0)
				break;
		}

		return [.. result];
	}

	private async Task<INamedResourceProviderDto> CreateDto()
	{
		var items = await resources.Lookup(Dto);
		var dto = Dto.Create<INamedResourceProviderDto>();

		foreach (var item in items)
		{
			dto.Items.Add(new ResourceDescriptor
			{
				Id = item.Id,
				Token = item.Token,
				Type = item.Type
			});
		}

		return dto;
	}
}
