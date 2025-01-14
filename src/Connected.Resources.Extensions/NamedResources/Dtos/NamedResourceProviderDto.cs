using Connected.Services;

namespace Connected.Resources.NamedResources.Dtos;
internal sealed class NamedResourceProviderDto : Dto, INamedResourceProviderDto
{
	public NamedResourceProviderDto()
	{
		Items = [];
	}
	public List<IResourceDescriptor> Items { get; set; }
}
