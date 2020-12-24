using FluentValidation;
using workLogger.DTOs;

namespace workLogger.Validation
{
  public class TaskValidator : AbstractValidator<TaskSendDto>
  {
    public TaskValidator()
    {
      RuleFor(task => task.Name).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.TaskNameMessage);
      RuleFor(task => task.ProjectNumber).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.TaskProjNumberMessage);
      RuleFor(task => task.HoursAvailableToWork).NotEmpty().GreaterThan(0).WithMessage(ValidationMessages.TaskValidationMessages.TaskProjNumberMessage);
      RuleFor(task => task.HoursWorked).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.HoursWorkedMessage);
      RuleFor(task => task.HoursRemaining).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.HoursRemainingMessage);
      RuleFor(task => task.NumberOfReviews).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.NumberOfReviewsMessage);
      RuleFor(task => task.ReviewHours).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.ReviewHoursMessage);
      RuleFor(task => task.HoursRequiredByBim).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.HoursBimMessage);
      RuleFor(task => task.UserId).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.UserIdMessage);

    }
  }
}