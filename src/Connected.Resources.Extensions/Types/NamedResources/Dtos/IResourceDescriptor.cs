namespace Connected.Resources.NamedResources.Dtos;
public interface IResourceDescriptor
{
	string Token { get; set; }
	int Id { get; set; }
	string? Type { get; set; }
}
