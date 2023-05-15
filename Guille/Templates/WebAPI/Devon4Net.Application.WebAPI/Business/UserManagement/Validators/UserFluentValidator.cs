using Devon4Net.Application.WebAPI.Business.UserManagement.Dto;
using Devon4Net.Infrastructure.FluentValidation;
using FluentValidation;

namespace Devon4Net.Application.WebAPI.Business.UserManagement.Validators
{
    /// <summary>
    /// UserFluentValidator implementation
    /// </summary>
    public class UserFluentValidator : CustomFluentValidator<UserDto>
    {
        /// <summary>
        /// UserFluentValidator constructor
        /// </summary>
        /// <param name="launchExceptionWhenError">Please set to false to not launching an exception</param>
        public UserFluentValidator(bool launchExceptionWhenError = false) : base(launchExceptionWhenError)
        {
        }

        /// <summary>
        /// Custom validation for UserDto
        /// </summary>
        public override void CustomValidate()
        {
            RuleFor(User => User.Username).NotNull();
            RuleFor(User => User.Username).NotEmpty();
            RuleFor(User => User.Password).NotNull();
            RuleFor(User => User.Password).NotEmpty();
        }
    }
}