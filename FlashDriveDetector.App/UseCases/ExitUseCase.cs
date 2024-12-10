using FlashDriveDetector.Core.Infrastructure;
using FlashDriveDetector.Core.Models;
using FlashDriveDetector.Core.UseCases;

namespace FlashDriveDetector.App.UseCases
{
    public class ExitUseCase : IExitUseCase
    {
        private readonly IMessageBox _messageBox;
        private readonly IDrivesProvider _drivesProvider;

        public ExitUseCase(
            IMessageBox messageBox,
            IDrivesProvider drivesProvider)
        {
            _messageBox = messageBox;
            _drivesProvider = drivesProvider;
        }

        public ExitState Execute()
        {
            if (_drivesProvider.GetDrives().Length > 0)
                return _messageBox.ExitQuestion();
            else
                return ExitState.Exit;
        }
    }
}