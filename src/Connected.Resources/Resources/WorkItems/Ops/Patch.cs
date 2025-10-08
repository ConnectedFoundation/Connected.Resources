using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Resources.Resources.WorkItems;
using Connected.Services;

namespace Connected.Resources.Resources.WorkItems.Ops;

internal sealed class Patch(IWorkItemService workItems) : ServiceAction<IPatchDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = await workItems.Select(Dto.AsDto<IPrimaryKeyDto<long>>()) as WorkItem ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await workItems.Update(Dto.Patch<IUpdateWorkItemDto, WorkItem>(entity));

	}
}
