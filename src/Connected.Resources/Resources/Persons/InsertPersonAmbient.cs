using Connected.Resources.Resources.Persons.Dtos;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Resources.Resources.Persons;
internal sealed class InsertPersonAmbient
	: AmbientProvider<IInsertPersonDto>, IInsertPersonAmbient
{
	public required string Token { get; set; }

    protected override async Task OnInvoke()
    {
        Token = Guid.NewGuid().ToString();

        await Task.CompletedTask;
    }
}
