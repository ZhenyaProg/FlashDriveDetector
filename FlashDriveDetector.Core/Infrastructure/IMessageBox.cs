using FlashDriveDetector.Core.Models;

namespace FlashDriveDetector.Core.Infrastructure
{
    public interface IMessageBox
    {
        ExitState ExitQuestion();
    }
}