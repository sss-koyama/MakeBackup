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
using System.Reflection;

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
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "MakeBackup.TextFiles.BackUp_week.sql";

            string sqlFileContent;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        sqlFileContent = sr.ReadToEnd();
                        //MessageBox.Show(sqlFileContent);
                        sqlFileContent = sqlFileContent.Replace("TARGETDB", txbDB.Text);
                        sqlFileContent = sqlFileContent.Replace("BACKUPPATH", txbPath.Text);
                        //MessageBox.Show(sqlFileContent);

                        string sqlFilePath = txbPath.Text + @"\BackUp.sql";
                        System.Text.Encoding sqlEnc = System.Text.Encoding.GetEncoding("UTF-8");
                        System.IO.File.WriteAllText(sqlFilePath, sqlFileContent, sqlEnc);
                    }
                }
            }

            string[] arrayStr =
            {
                "REM このバッチの文字コードはshift_jis、改行はCRLFにします。" ,
                "REM -f i:65001 でSQL実行時の文字コードをUTF - 8にします。",
                "REM これが抜けていると文字化けして日本語のディレクトリが開けません。",
                "REM このバッチファイルはSSMSがインストールされているサーバーまたはクライアントのローカルディレクトリに置きます。",
                "REM ネットワークドライブでは実行できません。" + Environment.NewLine

            };


            string batFilePath = txbPath.Text + @"\BackUp.bat";
            //文字コードをShift JIS
            System.Text.Encoding batEnc = System.Text.Encoding.GetEncoding("shift_jis");
            string tx = "sqlcmd -S ";
            tx = tx + txbSv.Text + " -E -f i:65001 -i " + "\"" + txbPath.Text + "\\" + "Backup.sql\" > \"" + txbPath.Text + @"\Backup.log" + "\"";
            System.IO.File.WriteAllLines(batFilePath, arrayStr, batEnc);
            System.IO.File.AppendAllText(batFilePath, tx, batEnc);

        }
    }
}
