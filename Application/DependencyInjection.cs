using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Application
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<InstructorValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TimetableValidator>());

            return services;
        }
    }
}
