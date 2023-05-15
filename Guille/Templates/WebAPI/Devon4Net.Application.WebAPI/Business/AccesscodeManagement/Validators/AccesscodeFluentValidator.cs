using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto;
using Devon4Net.Infrastructure.FluentValidation;
using FluentValidation;

namespace Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Validators
{
    /// <summary>
    /// AccesscodeFluentValidator implementation
    /// </summary>
    public class AccesscodeFluentValidator : CustomFluentValidator<AccesscodeDto>
    {
        /// <summary>
        /// AccesscodeFluentValidator constructor
        /// </summary>
        /// <param name="launchExceptionWhenError">Please set to false to not launching an exception</param>
        public AccesscodeFluentValidator(bool launchExceptionWhenError = false) : base(launchExceptionWhenError)
        {
        }

        /// <summary>
        /// Custom validation for AccesscodeDto
        /// </summary>
        public override void CustomValidate()
        {
            RuleFor(Accesscode => Accesscode.StartTime).NotNull();
            RuleFor(Accesscode => Accesscode.StartTime).NotEmpty();
            RuleFor(Accesscode => Accesscode.Status).NotNull();
            RuleFor(Accesscode => Accesscode.Status).NotEmpty();
            RuleFor(Accesscode => Accesscode.Code).NotNull();
            RuleFor(Accesscode => Accesscode.Code).NotEmpty();
        }
    }
}