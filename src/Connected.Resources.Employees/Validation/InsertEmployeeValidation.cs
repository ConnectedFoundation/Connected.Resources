using Connected.Common.Types.CostCenters;
using Connected.Common.Types.OrganizationUnits;
using Connected.Resources.Employees.Dtos;
using Connected.Resources.EmploymentTypes;
using Connected.Resources.JobPositions;
using Connected.Resources.Persons;
using Connected.Validation;

namespace Connected.Resources.Employees.Validation;
internal sealed class InsertEmployeeValidation(IPersonService persons, IOrganizationUnitService organizationUnits, IJobPositionService jobPositions,
	ICostCenterService costCenters, IEmployeeService employees, IEmploymentTypeService employmentTypes)
	: Validator<IInsertEmployeeDto>
{
	protected override async Task OnInvoke()
	{
		if (await persons.Select(Dto) is null)
			throw ValidationExceptions.NotFound(nameof(IPerson), Dto.Id);

		if (Dto.OrganizationUnit is not null)
		{
			if (await organizationUnits.Select(Dto) is null)
				throw ValidationExceptions.NotFound(nameof(IOrganizationUnit), Dto.OrganizationUnit);
		}

		if (Dto.JobPosition is not null)
		{
			if (await jobPositions.Select(Dto) is null)
				throw ValidationExceptions.NotFound(nameof(IJobPosition), Dto.JobPosition);
		}

		if (Dto.CostCenter is not null)
		{
			if (await costCenters.Select(Dto) is null)
				throw ValidationExceptions.NotFound(nameof(ICostCenter), Dto.CostCenter);
		}

		if (Dto.Parent is not null)
		{
			if (await employees.Select(Dto) is null)
				throw ValidationExceptions.NotFound(nameof(IEmployee), Dto.Parent);
		}

		if (Dto.EmploymentType is not null)
		{
			if (await employmentTypes.Select(Dto) is null)
				throw ValidationExceptions.NotFound(nameof(IEmploymentType), Dto.EmploymentType);
		}
	}
}
