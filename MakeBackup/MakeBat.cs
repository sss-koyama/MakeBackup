using System;
using System.Windows;

namespace MakeBackup
{
    class MakeBat
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public bool MakeBackupMethod(string sv, string path)
        {
            bool result = false;

            string[] arrayStr =
                {
                    "REM このバッチの文字コードはshift_jis、改行はCRLFにします。" ,
                    "REM -f i:65001 でSQL実行時の文字コードをUTF - 8にします。",
                    "REM これが抜けていると文字化けして日本語のディレクトリが開けません。",
                    "REM このバッチファイルはSSMSがインストールされているサーバーまたはクライアントのローカルディレクトリに置きます。",
                    "REM ネットワークドライブでは実行できません。" + Environment.NewLine,
                    "IF NOT EXIST \"" + path + "\\" + "Backup.sql\"" + " (" + Environment.NewLine,
                    "echo msgbox \"バックアップ先にアクセスできません。\" ^& vbCr ^& \"電源が入っているか、接続が切れていないか確認してください。\",vbCritical,\"SSSバックアップエラー\" > %~d0%~p0/msgboxtest.vbs & %~d0%~p0/msgboxtest.vbs" + Environment.NewLine,
                    @"DEL %~d0%~p0\msgboxtest.vbs" + Environment.NewLine,
                    ")"


                };

            try
            {
                string batFilePath = path + @"\BackUp.bat";
                //文字コードをShift JIS
                System.Text.Encoding batEnc = System.Text.Encoding.GetEncoding("shift_jis");
                string tx = "sqlcmd -S ";
                tx = tx + sv + " -E -f i:65001 -i " + "\"" + path + "\\" + "Backup.sql\" > \"" + path + @"\Backup.log" + "\"";
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
