using System;

namespace FlashDriveDetector.Core.UseCases
{
    public interface IShutdownUseCase
    {
        void Execute(IntPtr handle);
    }
}