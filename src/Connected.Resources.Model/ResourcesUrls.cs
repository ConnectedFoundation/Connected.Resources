namespace Connected.Resources;

public static class ResourcesUrls
{
	private const string Namespace = "services/resources";

	public const string TimeLogs = $"{Namespace}/time-logs";
	public const string TimeSheets = $"{Namespace}/time-sheets";
	public const string TimeSheetItems = $"{Namespace}/time-sheets/items";
	public const string WorkSheetItems = $"{Namespace}/work-sheets/items";
	public const string ResourceUtilization = $"{Namespace}/utilization/resources";
	public const string Effort = $"{Namespace}/effort";
	public const string Persons = $"{Namespace}/persons";
	public const string PersonContacts = $"{Namespace}/persons/contacts";
	public const string Employees = $"{Namespace}/employees";

	public const string SelectByResourceOperation = "select-by-resource";
	public const string QueryByDateOperation = "query-by-date";
	public const string LookupOperation = "lookup";
}
