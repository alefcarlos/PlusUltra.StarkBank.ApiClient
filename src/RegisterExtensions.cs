using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PlusUltra.ApiClient;
using PlusUltra.StarkBank.ApiClient.MessageHandlers;
using PlusUltra.StarkBank.ApiClient.Services;

namespace PlusUltra.StarkBank.ApiClient
{
    public static class RegisterExtensions
    {
        public static IServiceCollection AddStarkBank(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<StarkBankSettings>(configuration.GetSection(nameof(StarkBankSettings)));
            var configs = services.BuildServiceProvider().GetRequiredService<IOptions<StarkBankSettings>>().Value;

            services.AddTransient<StarkBankAuthenticationHeaderHandler>();

            services.AddApiClient<IStarkBankChargeClient>(c => c.BaseAddress = new Uri(configs.Uri))
                .AddHttpMessageHandler<StarkBankAuthenticationHeaderHandler>();

            services.AddApiClient<IStarkBankAuthClient>(c => c.BaseAddress = new Uri(configs.Uri));
            
            services.AddScoped<StarkBankChargeServices>();

            return services;
        }
    }
}