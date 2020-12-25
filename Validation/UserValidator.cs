using FluentValidation;
using workLogger.DTOs;

namespace workLogger.Validation
{
  public class UserValidator : AbstractValidator<UserSendDto>
  {
    public UserValidator()
    {
      RuleFor(user => user.FirstName).NotEmpty().WithMessage(ValidationMessages.UserValidationMessages.FirstNameMessage);
      RuleFor(user => user.LastName).NotEmpty().WithMessage(ValidationMessages.UserValidationMessages.LastNameMessage);
      RuleFor(user => user.Email).EmailAddress().WithMessage(ValidationMessages.UserValidationMessages.EmailMessage);
      RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage(ValidationMessages.UserValidationMessages.PasswordMessage);
    }
  }
}