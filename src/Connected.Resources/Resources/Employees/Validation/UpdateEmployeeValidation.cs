using Connected.Common.Types.CostCenters;
using Connected.Common.Types.OrganizationUnits;
using Connected.Resources.Resources.Employees.Dtos;
using Connected.Resources.Types.EmploymentTypes;
using Connected.Resources.Types.JobPositions;
using Connected.Services;
using Connected.Services.Validation;

namespace Connected.Resources.Resources.Employees.Validation;
internal sealed class UpdateEmployeeValidation(IOrganizationUnitService organizationUnits, IJobPositionService jobPositions,
	ICostCenterService costCenters, IEmployeeService employees, IEmploymentTypeService employmentTypes)
	: Validator<IUpdateEmployeeDto>
{
	protected override async Task OnInvoke()
	{
		if (Dto.OrganizationUnit is not null)
		{
			if (await organizationUnits.Select(Dto.CreatePrimaryKey(Dto.OrganizationUnit.Value)) is null)
				throw ValidationExceptions.NotFound(nameof(IOrganizationUnit), Dto.OrganizationUnit);
		}

		if (Dto.JobPosition is not null)
		{
			if (await jobPositions.Select(Dto.CreatePrimaryKey(Dto.JobPosition.Value)) is null)
				throw ValidationExceptions.NotFound(nameof(IJobPosition), Dto.JobPosition);
		}

		if (Dto.CostCenter is not null)
		{
			if (await costCenters.Select(Dto.CreatePrimaryKey(Dto.CostCenter.Value)) is null)
				throw ValidationExceptions.NotFound(nameof(ICostCenter), Dto.CostCenter);
		}

		if (Dto.Parent is not null)
		{
			if (await employees.Select(Dto.CreatePrimaryKey(Dto.Parent.Value)) is null)
				throw ValidationExceptions.NotFound(nameof(IEmployee), Dto.Parent);
		}

		if (Dto.EmploymentType is not null)
		{
			if (await employmentTypes.Select(Dto.CreatePrimaryKey(Dto.EmploymentType.Value)) is null)
				throw ValidationExceptions.NotFound(nameof(IEmploymentType), Dto.EmploymentType);
		}
	}
}
