using Connected.Common.Types.CostCenters;
using Connected.Common.Types.OrganizationUnits;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Resources.Resources.Persons;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Resources.Types.JobPositions;
using Connected.Resources.Types.JobPositions.Dtos;
using Connected.Services;
using Connected.Services.Validation;

namespace Connected.Resources.Resources.Employees.Validation;

internal sealed class InsertJobPositionValidation(IJobPositionService jobPositions)
    : Validator<IInsertJobPositionDto>
{
    protected override async Task OnInvoke()
    {
        var existing = (await jobPositions.Query(DtoFactory.Create<IQueryJobPositionDto>(f => f.Code = Dto.Code))).FirstOrDefault();

        if (existing is not null)
            throw ValidationExceptions.ValueExists<IJobPosition>(Dto.Code);
    }
}
