using FlashDriveDetector.Core;
using FlashDriveDetector.Core.Models;
using System.Windows.Forms;

namespace FlashDriveDetector.Infrastructure
{
    public class CustomMessageBox : IMessageBox
    {
        public ExitState ExitQuestion()
        {
            var result = MessageBox.Show("Есть активные флешки, хотите посмотреть?",
                                         "ПРЕДУПРЕЖДЕНИЕ",
                                         MessageBoxButtons.YesNoCancel,
                                         MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    return ExitState.ShowDrives;
                case DialogResult.No:
                    return ExitState.Exit;
                case DialogResult.Cancel:
                    return ExitState.Cancel;
                default:
                    return ExitState.None;
            }
        }
    }
}