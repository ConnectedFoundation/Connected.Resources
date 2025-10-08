using Connected.Annotations;

namespace Connected.Resources.ContactTypes;

[Service]
public interface IContactTypeExtensions
{
	Task<int?> ResolveEmailContactType();
}
