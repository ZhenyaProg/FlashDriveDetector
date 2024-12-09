using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.UseCases;

namespace FlashDriveDetector.App.UseCases
{
    public class EjectDriveUseCase : IEjectDriveUseCase
    {
        private readonly IDrivesProvider _drivesProvider;

        public EjectDriveUseCase(IDrivesProvider drivesProvider)
        {
            _drivesProvider = drivesProvider;
        }

        public string Execute(int driveIndex)
        {
            var drives = _drivesProvider.GetDrives();
            var driveName = drives[driveIndex].Name;
            var useableName = driveName.Substring(0, driveName.IndexOf(':') + 1);
            _drivesProvider.Eject(useableName);
            return useableName;
        }
    }
}