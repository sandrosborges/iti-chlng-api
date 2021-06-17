using iti.chalenge.api.domain.repositories;
using iti.chalenge.api.domain.repositories.interfaces;
using iti.chalenge.api.domain.services;
using iti.chalenge.api.domain.services.interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace iti.chalenge.api.configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<IPassValidatorService, PassValidatorService>();
            services.AddScoped<IRuleRepository, RuleRepository>();

        }
    }
}