using System;
using Microsoft.Extensions.DependencyInjection;
using Core;
using Core.Input;
using FlashDriveDetector.Forms;
using FlashDriveDetector.Infrastructure.DI;
using FlashDriveDetector.App.DI;

namespace FlashDriveDetector
{
    internal class AppContext : BaseAppContext
    {
        public AppContext() : base()
        {
        }

        protected override Type Form => typeof(BackgroundForm);

        protected override Func<InputController, BaseForm[]> FormsFactory => (inputController) =>
        {
            IServiceCollection serviceCollection = new ServiceCollection()
                                                       .AddInfrastructure()
                                                       .AddUseCases();
                
            var provider = serviceCollection.BuildServiceProvider();

            return new BaseForm[]
            {
                new BackgroundForm(provider),
                new DrivesForm(provider),
            };
        };
    }
}