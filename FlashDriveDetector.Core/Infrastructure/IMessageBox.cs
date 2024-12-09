using FlashDriveDetector.Core.Models;

namespace FlashDriveDetector.Core
{
    public interface IMessageBox
    {
        ExitState ExitQuestion();
    }

    //    DialogResult result = MessageBox.Show(this, 
    //                                          "Есть активные флешки, хотите их посмотреть?",
    //                                          "ПРЕДУПРЕЖДЕНИЕ",
    //                                          MessageBoxButtons.YesNoCancel,
    //                                          MessageBoxIcon.Warning);
}