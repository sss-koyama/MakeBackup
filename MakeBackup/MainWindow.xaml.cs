using System;
using System.Windows;
using Microsoft.Win32;

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
            //ラジオボタンのチェックを値に
            string rbtFlg = "";

if (rbtWeek.IsChecked == true)
            {
                rbtFlg = "week";
            }
            else if (rbtMonth.IsChecked == true)
            {
                rbtFlg = "month";
            }
            else
            {
                MessageBox.Show("バックアップ間隔を選択してください。", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MakeDir makeDir = new MakeDir();
            bool dirresult = makeDir.MakeDirMethod(rbtFlg, txbPath.Text);

            MakeSQL makeSQL = new MakeSQL();
            bool SQLresult = makeSQL.MakeSQLMethod();

            MakeBat makeBat = new MakeBat();
            bool batresurt = makeBat.MakeBackupMethod(txbSv.Text,txbPath.Text);

            if ((dirresult == true) && (SQLresult == true) && (batresurt == true))
            {
                MessageBox.Show("バックアップフォルダを確認してください。", "作成しました", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //string[] dirNames =
            //{
            //    "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa",
            //    "1", "6", "11", "16", "21", "26"
            //};

            //foreach(string dirName in dirNames)
            //{
            //    string dirPath = txbPath.Text + @"\" + dirName;

            //    Directory.CreateDirectory(dirPath);
            //}

            //var assembly = Assembly.GetExecutingAssembly();
            //var resourceName = "MakeBackup.TextFiles.BackUp_week.sql";

            //string sqlFileContent;
            //using (var stream = assembly.GetManifestResourceStream(resourceName))
            //{
            //    if (stream != null)
            //    {
            //        using (var sr = new StreamReader(stream))
            //        {
            //            sqlFileContent = sr.ReadToEnd();
            //            //MessageBox.Show(sqlFileContent);
            //            sqlFileContent = sqlFileContent.Replace("TARGETDB", txbDB.Text);
            //            sqlFileContent = sqlFileContent.Replace("BACKUPPATH", txbPath.Text);
            //            //MessageBox.Show(sqlFileContent);

            //            string sqlFilePath = txbPath.Text + @"\BackUp.sql";
            //            System.Text.Encoding sqlEnc = System.Text.Encoding.GetEncoding("UTF-8");
            //            System.IO.File.WriteAllText(sqlFilePath, sqlFileContent, sqlEnc);
            //        }
            //    }
            //}

            //string[] arrayStr =
            //{
            //    "REM このバッチの文字コードはshift_jis、改行はCRLFにします。" ,
            //    "REM -f i:65001 でSQL実行時の文字コードをUTF - 8にします。",
            //    "REM これが抜けていると文字化けして日本語のディレクトリが開けません。",
            //    "REM このバッチファイルはSSMSがインストールされているサーバーまたはクライアントのローカルディレクトリに置きます。",
            //    "REM ネットワークドライブでは実行できません。" + Environment.NewLine

            //};


            //string batFilePath = txbPath.Text + @"\BackUp.bat";
            ////文字コードをShift JIS
            //System.Text.Encoding batEnc = System.Text.Encoding.GetEncoding("shift_jis");
            //string tx = "sqlcmd -S ";
            //tx = tx + txbSv.Text + " -E -f i:65001 -i " + "\"" + txbPath.Text + "\\" + "Backup.sql\" > \"" + txbPath.Text + @"\Backup.log" + "\"";
            //System.IO.File.WriteAllLines(batFilePath, arrayStr, batEnc);
            //System.IO.File.AppendAllText(batFilePath, tx, batEnc);

        }

        private void btnReadme_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow readme = new HelpWindow();
            readme.ShowDialog();
        }

        private void btnSelectDir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = "GetFolderName.";
                dlg.CheckFileExists = false;
                dlg.Title = "フォルダを選択してください";

                if (dlg.ShowDialog() == true)
                {
                    string path = System.IO.Path.GetDirectoryName(dlg.FileName);

                    txbPath.Text = path;
                }
                //SelectDir selectdir = new SelectDir();
                //string path = selectdir.SelectDirMethod();

                //txbPath.Text = path;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "失敗");
            }
            
        }
    }
}
