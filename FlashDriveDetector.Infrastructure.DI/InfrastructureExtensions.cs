using FlashDriveDetector.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace FlashDriveDetector.Infrastructure.DI
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IMessageBox, CustomMessageBox>();
            services.AddSingleton<IDrivesProvider, DrivesProvider>();

            return services;
        }
    }
}