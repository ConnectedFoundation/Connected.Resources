using Connected.Resources.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.WorkItems.Ops;

internal sealed class Patch(IWorkItemService workItems) : ServiceAction<IPatchDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = await workItems.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as WorkItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await workItems.Update(Dto.Patch<IUpdateWorkItemDto, WorkItem>(entity));

	}
}
