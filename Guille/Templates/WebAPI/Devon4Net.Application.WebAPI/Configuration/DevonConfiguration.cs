using Devon4Net.Application.WebAPI.Domain.Database;
using Devon4Net.Domain.UnitOfWork.Common;
using Devon4Net.Domain.UnitOfWork.Enums;
using Devon4Net.Infrastructure.Common.Constants;
using Devon4Net.Infrastructure.FluentValidation;
using Devon4Net.Infrastructure.JWT.Common;
using Devon4Net.Infrastructure.MediatR.Options;
using Devon4Net.Infrastructure.MediatR.Samples.Handler;
using Devon4Net.Infrastructure.MediatR.Samples.Query;
using Devon4Net.Infrastructure.RabbitMQ.Options;
using Devon4Net.Infrastructure.RabbitMQ.Samples.Handllers;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Devon4Net.Infrastructure.RabbitMQ;
using Devon4Net.Application.WebAPI.Business.UserManagement.Validators;
using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Validators;
using Devon4Net.Application.WebAPI.Business.AccesscodeManagement.Dto;
using Devon4Net.Application.WebAPI.Business.QueueManagement.Validators;
using Devon4Net.Application.WebAPI.Business.QueueManagement.Dto;
using UserDto = Devon4Net.Application.WebAPI.Business.UserManagement.Dto.UserDto;
using MediatRUserDto = Devon4Net.Infrastructure.MediatR.Samples.Model.UserDto;

namespace Devon4Net.Application.WebAPI.Configuration
{
    /// <summary>
    /// DevonConfiguration class
    /// </summary>
    public static class DevonConfiguration
    {
        /// <summary>
        /// Sets up the service dependency injection
        /// For example:
        /// services.AddTransient"ITodoService, TodoService"();
        /// services.AddTransient"ITodoRepository, TodoRepository"();
        /// Put your DI declarations here
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void SetupCustomDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            SetupDatabase(services, configuration);
            SetupJwtPolicies(services);
            SetupFluentValidators(services);

            using var serviceProvider = services.BuildServiceProvider();

            var mediatR = serviceProvider.GetService<IOptions<MediatROptions>>();
            var rabbitMq = serviceProvider.GetService<IOptions<RabbitMqOptions>>();

            if (rabbitMq?.Value != null && rabbitMq.Value.EnableRabbitMq)
            {
                SetupRabbitHandlers(services);
            }

            if (mediatR?.Value != null && mediatR.Value.EnableMediatR)
            {
                SetupMediatRHandlers(services);
            }
        }

        private static void SetupRabbitHandlers(IServiceCollection services)
        {
            services.AddRabbitMqHandler<UserSampleRabbitMqHandler>(true);
        }

        private static void SetupMediatRHandlers(IServiceCollection services)
        {
            services.AddTransient(typeof(IRequestHandler<GetUserQuery, MediatRUserDto>), typeof(GetUserhandler));
        }

        private static void SetupFluentValidators(IServiceCollection services)
        {
            services.AddFluentValidation<IValidator<UserDto>, UserFluentValidator>();
            services.AddFluentValidation<IValidator<AccesscodeDto>, AccesscodeFluentValidator>();
            services.AddFluentValidation<IValidator<QueueDto>, QueueFluentValidator>();
        }

        /// <summary>
        /// Setup here your database connections.
        /// To use RabbitMq message backup declare the 'RabbitMqBackupContext' database setup
        /// PE: services.SetupDatabase&lt;RabbitMqBackupContext&gt;($"Data Source={FileOperations.GetFileFullPath("RabbitMqBackupSqLite.db")}", DatabaseType.Sqlite);
        /// Please add the connection strings to enable the backup messaging for MediatR abd RabbitMq using MediatRBackupContext and RabbitMqBackupContext
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void SetupDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDatabase<TodoContext>(configuration, "Default", DatabaseType.InMemory).ConfigureAwait(false);
            services.SetupDatabase<EmployeeContext>(configuration, "Employee", DatabaseType.InMemory).ConfigureAwait(false);
            services.SetupDatabase<MyContext>(configuration, "MyContext", DatabaseType.SqlServer).ConfigureAwait(false);
        }

        private static void SetupJwtPolicies(IServiceCollection services)
        {
            services.AddJwtPolicy(AuthConst.DevonSamplePolicy, ClaimTypes.Role, AuthConst.DevonSampleUserRole);
        }
    }
}
