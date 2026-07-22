using Connected.Annotations;
using Connected.Resources.Persons.Dtos;
using Connected.Services;

namespace Connected.Resources.Persons;

[Service]
public interface IPersonExtensions
{
	Task<string?> ResolveEmail(IResolveEmailDto dto);
	Task<string?> ResolvePhoneNumber(IResolveEmailDto dto);
}
