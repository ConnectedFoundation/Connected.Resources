using Connected.Annotations;
using Connected.Notifications;
using Connected.Resources.WorkItems;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.Utilization.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Updated)]
internal sealed class UpdatedWorkItem(IWorkItemService workItems, IResourceUtilizationService utilization)
	: EventListener<IUpdateWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var state = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var workItem = await workItems.Select(Dto.CreatePrimaryKey(state.Id)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		if (state.Resource is not null && state.Resource != workItem.Resource)
			await new UtilizationCalculator(workItems, utilization, state).Calculate();

		await new UtilizationCalculator(workItems, utilization, workItem).Calculate();
	}
}
