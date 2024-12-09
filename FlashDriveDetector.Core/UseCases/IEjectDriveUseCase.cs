namespace FlashDriveDetector.Core.UseCases
{
    public interface IEjectDriveUseCase
    {
        string Execute(int driveIndex);
    }
}