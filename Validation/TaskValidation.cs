using FluentValidation;
using workLogger.DTOs;

namespace workLogger.Validation
{
  public class TaskValidator : AbstractValidator<TaskSendDto>
  {
    public TaskValidator()
    {
      RuleFor(task => task.Name).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.TaskNameMessage);
      RuleFor(task => task.HoursAvailableToWork).NotEmpty().GreaterThan(0).WithMessage(ValidationMessages.TaskValidationMessages.TaskProjNumberMessage);
      RuleFor(task => task.HoursWorked).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.HoursWorkedMessage);
      RuleFor(task => task.HoursRemaining).NotEmpty().WithMessage(ValidationMessages.TaskValidationMessages.HoursRemainingMessage);
      RuleFor(task => task.ReviewHours).GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.TaskValidationMessages.ReviewHoursMessage);
      RuleFor(task => task.HoursRequiredByBim).GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.TaskValidationMessages.HoursBimMessage);
      RuleFor(task => task.UserId).GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.TaskValidationMessages.UserIdMessage);
      RuleFor(task => task.NumberOfReviews).GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.TaskValidationMessages.NumberOfReviewsMessage);
    }
  }
}