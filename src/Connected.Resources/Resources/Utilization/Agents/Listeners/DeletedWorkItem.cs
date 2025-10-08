using Connected.Annotations;
using Connected.Notifications;
using Connected.Resources.Documents.WorkItems;
using Connected.Resources.Documents.WorkItems.Dtos;
using Connected.Resources.Resources.Utilization;
using Connected.Services;

namespace Connected.Resources.Resources.Utilization.Agents.Listeners;

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
