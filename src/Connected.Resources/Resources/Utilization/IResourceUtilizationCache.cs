using Connected.Caching;

namespace Connected.Resources.Resources.Utilization;

internal interface IResourceUtilizationCache : ICacheContainer<ResourceUtilization, long>
{
}
