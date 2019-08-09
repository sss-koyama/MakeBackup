using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MakeBackup
{
    class MakeBat
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public bool MakeBackupMethod()
        {
            bool result = false;

            string[] arrayStr =
{
                "REM このバッチの文字コードはshift_jis、改行はCRLFにします。" ,
                "REM -f i:65001 でSQL実行時の文字コードをUTF - 8にします。",
                "REM これが抜けていると文字化けして日本語のディレクトリが開けません。",
                "REM このバッチファイルはSSMSがインストールされているサーバーまたはクライアントのローカルディレクトリに置きます。",
                "REM ネットワークドライブでは実行できません。" + Environment.NewLine

            };

            try
            {
                string batFilePath = mainWindow.txbPath.Text + @"\BackUp.bat";
                //文字コードをShift JIS
                System.Text.Encoding batEnc = System.Text.Encoding.GetEncoding("shift_jis");
                string tx = "sqlcmd -S ";
                tx = tx + mainWindow.txbSv.Text + " -E -f i:65001 -i " + "\"" + mainWindow.txbPath.Text + "\\" + "Backup.sql\" > \"" + mainWindow.txbPath.Text + @"\Backup.log" + "\"";
                System.IO.File.WriteAllLines(batFilePath, arrayStr, batEnc);
                System.IO.File.AppendAllText(batFilePath, tx, batEnc);

                result = true;
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "バッチファイルの作成に失敗しました。", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
                return result;
            }
            
        }
    }
}
