using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TickTime.Application.Pipelines;
using TickTime.Application.Services;

namespace TickTime.Application
{
    public static class Configure
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(Configure).Assembly;

            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);

            services.AddTransient<Repository>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipe<,>));
        }
    }
}
