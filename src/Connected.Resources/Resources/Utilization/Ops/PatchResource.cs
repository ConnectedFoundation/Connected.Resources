using Connected.Resources.Resources.Utilization;
using Connected.Resources.Resources.Utilization.Dtos;
using Connected.Services;

namespace Connected.Resources.Resources.Utilization.Ops;

internal sealed class PatchResource(IResourceUtilizationService resources)
	: ServiceAction<IPatchDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = await resources.Select(Dto) ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var dto = Dto.Patch<UpdateResourceUtilizationDto, IResourceUtilization>(entity);

		await resources.Update(dto);
	}
}
