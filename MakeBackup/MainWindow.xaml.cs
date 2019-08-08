using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MakeBackup
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string[] arrayStr =
            {
                "REM このバッチの文字コードはshift_jis、改行はCRLFにします。" ,
                "REM -f i:65001 でSQL実行時の文字コードをUTF - 8にします。",
                "REM これが抜けていると文字化けして日本語のディレクトリが開けません。",
                "REM このバッチファイルはSSMSがインストールされているサーバーまたはクライアントのローカルディレクトリに置きます。",
                "REM ネットワークドライブでは実行できません。" + Environment.NewLine

            };

            string batFilePath = @"C:\Users\X270-01\Desktop\Backup.bat";
            //文字コードをShift JIS
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("shift_jis");
            string tx = "sqlcmd -S ";
            tx = tx + txbSv.Text + " -E -f i:65001 -i " + "\"" + txbPath.Text + "\\" + "Backup.sql\" > \"" + txbPath.Text + @"\Backup.log" + "\"";
            System.IO.File.WriteAllLines(batFilePath, arrayStr, enc);
            System.IO.File.AppendAllText(batFilePath, tx, enc);

        }
    }
}
