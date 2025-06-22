using Connected.Caching;

namespace Connected.Resources.Utilization;

internal interface IResourceUtilizationCache : ICacheContainer<ResourceUtilization, long>
{
}
