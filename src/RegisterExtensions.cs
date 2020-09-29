using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlusUltra.ApiClient;
using PlusUltra.StarkBank.ApiClient.MessageHandlers;
using PlusUltra.StarkBank.ApiClient.Services;

namespace PlusUltra.StarkBank.ApiClient
{
    public static class RegisterExtensions
    {
        public static IServiceCollection AddStarkBank(this IServiceCollection services, IConfiguration configuration)
        {
            var configs = new StarkBankSettings();
            var section = configuration.GetSection(nameof(StarkBankSettings));
            section.Bind(configs);

            services.Configure<StarkBankSettings>(section);
            

            services.AddTransient<StarkBankAuthenticationHeaderHandler>();

            services.AddApiClient<IStarkBankChargeClient>(c => c.BaseAddress = new Uri(configs.Uri))
                .AddHttpMessageHandler<StarkBankAuthenticationHeaderHandler>();

            services.AddApiClient<IStarkBankAuthClient>(c => c.BaseAddress = new Uri(configs.Uri));
            
            services.AddScoped<StarkBankChargeServices>();

            return services;
        }
    }
}