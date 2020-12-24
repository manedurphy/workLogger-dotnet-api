namespace workLogger.Validation
{
  public static class ValidationMessages
  {
    public static class TaskValidationMessages
    {
      public const string TaskNameMessage = "Please enter a name for your task";
      public const string TaskProjNumberMessage = "Task must have a unique project number";
      public const string HoursAvailableMessage = "Hours available must be greater than 0";
      public const string HoursWorkedMessage = "Please enter the number of hours you have worked on this task";
      public const string HoursRemainingMessage = "Please enter the number of hours remaining for this task";
      public const string NumberOfReviewsMessage = "Please enter the number of reviews assigned for this task";
      public const string ReviewHoursMessage = "Please enter the number of review hours for this task";
      public const string HoursBimMessage = "Please enter the number of hours required by BIM";
      public const string UserIdMessage = "Please enter the Id of the user associated with this task";
    }
  }
}