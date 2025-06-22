using Connected.Annotations.Entities;
using Connected.Resources.Effort;
using Connected.Resources.TimeLogs;
using Connected.Resources.TimeSheets;
using Connected.Resources.TimeSheets.Items;
using Connected.Resources.Utilization;
using Connected.Resources.WorkSheets;

namespace Connected.Resources;

public static class ResourcesMetaData
{
	public const string TimeLogKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeLog)}";
	public const string TimeSheetKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeSheet)}";
	public const string TimeSheetItemKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeSheetItem)}";
	public const string WorkSheetItemKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IWorkSheetItem)}";
	public const string ResourceUtilizationKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IResourceUtilization)}";
	public const string EffortKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IEffort)}";

}
