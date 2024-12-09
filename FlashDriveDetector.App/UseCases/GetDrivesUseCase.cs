using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.UseCases;
using System;

namespace FlashDriveDetector.App.UseCases
{
    public class GetDrivesUseCase : IGetDrivesUseCase
    {
        private readonly IDrivesProvider _drivesProvider;

        public GetDrivesUseCase(IDrivesProvider drivesProvider)
        {
            _drivesProvider = drivesProvider;
        }

        public string[] Execute()
        {
            var drives = _drivesProvider.GetDrives();
            string[] drivesInfo = new string[drives.Length];
            for (int i = 0; i < drivesInfo.Length; i++)
            {
                drivesInfo[i] = $"{drives[i].VolumeLabel} ({drives[i].Name}) {drives[i].TotalSize * Math.Pow(10, -9)}";
            }
            return drivesInfo;
        }
    }
}