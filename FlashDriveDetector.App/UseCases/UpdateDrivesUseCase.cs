using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.UseCases;

namespace FlashDriveDetector.App.UseCases
{
    public class UpdateDrivesUseCase : IUpdateDrivesUseCase
    {
        private readonly IDrivesProvider _drivesProvider;

        public UpdateDrivesUseCase(IDrivesProvider drivesProvider)
        {
            _drivesProvider = drivesProvider;
        }

        public void Execute()
        {
            _drivesProvider.Update();
        }
    }
}