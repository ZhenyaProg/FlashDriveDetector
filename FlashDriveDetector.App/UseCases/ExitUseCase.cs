using FlashDriveDetector.Core;
using FlashDriveDetector.Core.Models;
using FlashDriveDetector.Core.UseCases;

namespace FlashDriveDetector.App.UseCases
{
    public class ExitUseCase : IExitUseCase
    {
        private readonly IMessageBox _messageBox;

        public ExitUseCase(IMessageBox messageBox)
        {
            _messageBox = messageBox;
        }

        public ExitState Execute() => _messageBox.ExitQuestion();
    }
}