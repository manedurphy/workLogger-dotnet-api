using System;
using FluentValidation;
using FluentValidation.Results;
using workLogger.Models;

namespace workLogger.Validation
{
  public class UserValidator : AbstractValidator<User>
  {
    public UserValidator()
    {
      RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is required");
      RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required");
      RuleFor(user => user.Email).EmailAddress().WithMessage("Invalid email address");
      RuleFor(user => user.Password).NotEmpty().MinimumLength(6).WithMessage("Invalid password. Please make sure you have enough characters.");
    }
  }
}