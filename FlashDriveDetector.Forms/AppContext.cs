using FlashDriveDetector.Forms;
using Core;
using Core.Input;
using System;
using FlashDriveDetector.Core.UseCases;
using FlashDriveDetector.App.UseCases;
using FlashDriveDetector.Core;
using FlashDriveDetector.Infrastructure;
using FlashDriveDetector.Core.Infrastructure;

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
            IMessageBox messageBox = new CustomMessageBox();
            IDrivesProvider drivesProvider = new DrivesProvider();

            IExitUseCase exitUseCase = new ExitUseCase(messageBox);
            IShutdownUseCase shutdownUseCase = new ShutdownUseCase(drivesProvider);
            IUpdateDrivesUseCase updateUseCase = new UpdateDrivesUseCase(drivesProvider);

            IEjectDriveUseCase ejectUseCase = new EjectDriveUseCase(drivesProvider);
            IGetDrivesUseCase getDrivesUseCase = new GetDrivesUseCase(drivesProvider);

            return new BaseForm[]
            {
                new BackgroundForm(exitUseCase, shutdownUseCase, updateUseCase),
                new DrivesForm(ejectUseCase, getDrivesUseCase, drivesProvider),
            };
        };
    }
}