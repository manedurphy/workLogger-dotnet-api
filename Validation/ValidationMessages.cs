namespace workLogger.Validation
{
  public static class ValidationMessages
  {
    public static class TaskValidationMessages
    {
      public const string TaskNameMessage = "Please enter a name for your task";
      public const string TaskProjNumberMessage = "Task must have a unique project number";
      public const string HoursAvailableMessage = "Hours available to work must be greater than 0";
      public const string HoursWorkedMessage = "Hours worked on a task must be greater than or equal to 0";
      public const string HoursRemainingMessage = "Hours remaining for a task must be greater than or equal to 0";
      public const string NumberOfReviewsMessage = "Number of reviews must be greater than or equal to 0";
      public const string ReviewHoursMessage = "Review hours must be greater than or equal to 0";
      public const string HoursBimMessage = "Hours required by BIM must be greater than or equal to 0";
      public const string UserIdMessage = "Please enter the Id of the user associated with this task";
    }
  }
}