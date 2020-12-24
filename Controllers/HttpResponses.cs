namespace workLogger.Controllers
{
  public static class HttpResponses
  {
    public static class UserResponses
    {
      public const string UserNotFound = "User was not found";
      public const string UserExists = "User with that email already exists";

    }

    public static class TaskResponses
    {
      public const string TaskNotFound = "Task was not found";
      public const string TaskExists = "Task with this Project Number already exists";
    }
  }
}