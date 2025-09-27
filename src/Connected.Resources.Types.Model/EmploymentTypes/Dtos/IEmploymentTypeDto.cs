using Connected.Entities;
using Connected.Services;

namespace Connected.Resources.EmploymentTypes.Dtos;
public interface IEmploymentTypeDto : IDto
{
	string Name { get; set; }
	string Code { get; set; }
	Status Status { get; set; }
}
