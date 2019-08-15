using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;



namespace MakeBackup
{
    class SelectDir
    {
        public string SelectDirMethod()
        {
            string path = "";

            var dlg = new CommonOpenFileDialog("フォルダ選択");
            dlg.IsFolderPicker = true;
            var ret = dlg.ShowDialog();
            if (ret == CommonFileDialogResult.Ok)
            {
                path = dlg.FileName;

                return path;
            }

            return path;
        }
    }
        
}
