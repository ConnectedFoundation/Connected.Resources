using Connected.Resources.NamedResources.Dtos;
using Connected.Services;

namespace Connected.Resources.NamedResources.Ops;
internal sealed class Select(IMiddlewareService middlewares, IResourceService resources)
	: ServiceFunction<IPrimaryKeyDto<int>, INamedResource?>
{
	protected override async Task<INamedResource?> OnInvoke()
	{
		var providers = middlewares.Query<INamedResourceProvider>();
		var dto = CreateDto();

		Task.WaitAll(providers, dto);

		if (dto.Result is null)
			return null;

		foreach (var provider in providers.Result)
		{
			var namedResources = await provider.Invoke(dto.Result);

			if (!namedResources.IsEmpty)
				return namedResources[0];
		}

		return null;
	}

	private async Task<INamedResourceProviderDto?> CreateDto()
	{
		var item = await resources.Select(Dto);

		if (item is null)
			return null;

		var dto = Dto.Create<INamedResourceProviderDto>();

		dto.Items.Add(new ResourceDescriptor
		{
			Id = item.Id,
			Token = item.Token,
			Type = item.Type
		});

		return dto;
	}
}
