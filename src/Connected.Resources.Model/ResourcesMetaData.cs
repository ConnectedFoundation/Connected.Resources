using Connected.Annotations.Entities;
using Connected.Resources.Resources.Effort;
using Connected.Resources.Resources.Employees;
using Connected.Resources.Resources.Persons;
using Connected.Resources.Resources.Persons.Contacts;
using Connected.Resources.Resources.TimeLogs;
using Connected.Resources.Resources.TimeSheets;
using Connected.Resources.Resources.TimeSheets.Items;
using Connected.Resources.Resources.Utilization;
using Connected.Resources.Resources.WorkSheets;

namespace Connected.Resources;

public static class ResourcesMetaData
{
	public const string TimeLogKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeLog)}";
	public const string TimeSheetKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeSheet)}";
	public const string TimeSheetItemKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(ITimeSheetItem)}";
	public const string WorkSheetItemKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IWorkSheetItem)}";
	public const string ResourceUtilizationKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IResourceUtilization)}";
	public const string EffortKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IEffort)}";
	public const string PersonKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IPerson)}";
	public const string PersonContactKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IPersonContact)}";
	public const string EmployeeKey = $"{SchemaAttribute.ResourcesSchema}.{nameof(IEmployee)}";

	public const string SelectByCodeOperation = "select-by-code";
}
