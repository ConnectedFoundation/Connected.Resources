using Connected.Annotations;
using Connected.Notifications;
using Connected.Resources.WorkItems;
using Connected.Resources.WorkItems.Dtos;
using Connected.Services;

namespace Connected.Resources.Utilization.Listeners;
/// <summary>
/// This middleware calculates utilization for the resource assigned to the work item if any.
/// </summary>
/// <param name="workItems">Service providing work items.</param>
/// <param name="utilization">Service providing utilization.</param>
[Middleware<IWorkItemService>(ServiceEvents.Inserted)]
internal class InsertedWorkItem(IWorkItemService workItems, IResourceUtilizationService utilization)
	: EventListener<IInsertWorkItemDto>
{
	protected override async Task OnInvoke()
	{
		var workItem = Sender.GetState<IWorkItem>() ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await new UtilizationCalculator(workItems, utilization, workItem).Calculate();
	}
}
