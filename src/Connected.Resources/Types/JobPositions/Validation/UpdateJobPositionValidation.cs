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

internal sealed class UpdateJobPositionValidation(IJobPositionService jobPositions)
    : Validator<IUpdateJobPositionDto>
{
    protected override async Task OnInvoke()
    {
        var existing = (await jobPositions.Query(DtoFactory.Create<IQueryJobPositionDto>(f => f.Code = Dto.Code))).FirstOrDefault(f => f.Id != Dto.Id);

        if (existing is not null)
            throw ValidationExceptions.ValueExists<IJobPosition>(Dto.Code);
    }
}
