using Connected.Entities;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Resources.Resources.Employees.Ops;

internal sealed class Query(IEmployeeCache cache)
    : ServiceFunction<IQueryEmployeesDto, IImmutableList<IEmployee>>
{
    protected override async Task<IImmutableList<IEmployee>> OnInvoke()
    {
        var query = cache.AsQueryable();

        if (Dto.OrganizationUnits is { Count: > 0 })
            query = query.Where(f => f.OrganizationUnit.HasValue && Dto.OrganizationUnits.Contains(f.OrganizationUnit.Value));

        return await query.AsEntities();
    }
}
