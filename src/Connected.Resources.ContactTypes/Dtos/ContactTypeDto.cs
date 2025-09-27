using Connected.Entities;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.ContactTypes.Dtos;
internal abstract class ContactTypeDto : Dto, IContactTypeDto
{
	[Required, MaxLength(DefaultNameLength)]
	public required string Name { get; set; }

	public Status Status { get; set; }
}
