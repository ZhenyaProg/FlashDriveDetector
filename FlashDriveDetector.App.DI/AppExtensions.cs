using FlashDriveDetector.App.UseCases;
using FlashDriveDetector.Core.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace FlashDriveDetector.App.DI
{
    public static class AppExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IExitUseCase, ExitUseCase>();
            services.AddTransient<IShutdownUseCase, ShutdownUseCase>();
            services.AddTransient<IUpdateDrivesUseCase, UpdateDrivesUseCase>();
            services.AddTransient<IEjectDriveUseCase, EjectDriveUseCase>();
            services.AddTransient<IGetDrivesUseCase, GetDrivesUseCase>();

            return services;
        }
    }
}