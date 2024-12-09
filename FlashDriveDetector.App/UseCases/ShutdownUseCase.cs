using FlashDriveDetector.Core;
using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.UseCases;
using System;
using System.Text;

namespace FlashDriveDetector.App.UseCases
{
    public class ShutdownUseCase : IShutdownUseCase
    {
        private readonly IDrivesProvider _drivesProvider;

        public ShutdownUseCase(IDrivesProvider drivesProvider)
        {
            _drivesProvider = drivesProvider;
        }

        public void Execute(IntPtr handle)
        {
            var drives = _drivesProvider.GetDrives();
            if (drives.Length > 0)
            {
                StringBuilder stringBuilder = new StringBuilder($"ПК не может быть выключен, пока активны {drives.Length} флешек: \r\n");
                foreach (var drive in drives)
                    stringBuilder.Append($"\t {drive.VolumeLabel} ({drive.Name}) {drive.TotalSize * Math.Pow(10, -9)}");

                Imports.ShutdownBlockReasonCreate(handle, stringBuilder.ToString());
            }
        }
    }
}