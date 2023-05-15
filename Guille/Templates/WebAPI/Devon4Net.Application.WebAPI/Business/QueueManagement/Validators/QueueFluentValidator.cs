using Devon4Net.Application.WebAPI.Business.QueueManagement.Dto;
using Devon4Net.Infrastructure.FluentValidation;
using FluentValidation;

namespace Devon4Net.Application.WebAPI.Business.QueueManagement.Validators
{
    /// <summary>
    /// QueueFluentValidator implementation
    /// </summary>
    public class QueueFluentValidator : CustomFluentValidator<QueueDto>
    {
        /// <summary>
        /// QueueFluentValidator constructor
        /// </summary>
        /// <param name="launchExceptionWhenError">Please set to false to not launching an exception</param>
        public QueueFluentValidator(bool launchExceptionWhenError = false) : base(launchExceptionWhenError)
        {
        }

        /// <summary>
        /// Custom validation for QueueDto
        /// </summary>
        public override void CustomValidate()
        {
            RuleFor(Queue => Queue.Logo).NotNull();
            RuleFor(Queue => Queue.Logo).NotEmpty();
            RuleFor(Queue => Queue.Name).NotNull();
            RuleFor(Queue => Queue.Name).NotEmpty();
            RuleFor(Queue => Queue.Description).NotNull();
            RuleFor(Queue => Queue.Description).NotEmpty();
            RuleFor(Queue => Queue.Link).NotNull();
            RuleFor(Queue => Queue.Link).NotEmpty();
            RuleFor(Queue => Queue.OpenTime).NotNull();
            RuleFor(Queue => Queue.OpenTime).NotEmpty();
            RuleFor(Queue => Queue.CloseTime).NotNull();
            RuleFor(Queue => Queue.CloseTime).NotEmpty();
        }
    }
}