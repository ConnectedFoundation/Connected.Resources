using Connected.Annotations;
using Connected.Notifications;
using Connected.Resources.WorkItems;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.Utilization.Listeners;

[Middleware<IWorkItemService>(ServiceEvents.Deleted)]
internal sealed class DeletedWorkItem(IWorkItemService workItems, IResourceUtilizationService utilization)
	: EventListener<IUpdateWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var state = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await new UtilizationCalculator(workItems, utilization, state).Calculate();
	}
}
