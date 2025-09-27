using Connected.Caching;

namespace Connected.Resources.Persons;
public interface IPersonCache
	: IEntityCache<IPerson, int>
{
}
