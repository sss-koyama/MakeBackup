using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MakeBackup
{
    class MakeSQL
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public bool MakeSQLMethod()
        {
            
            bool result = false;

            var assembly = Assembly.GetExecutingAssembly();

            string resourceName = "";

            if(mainWindow.rbtWeek.IsChecked == true)
            {
                resourceName = "MakeBackup.TextFiles.BackUp_week.sql";
            }

            else if(mainWindow.rbtMonth.IsChecked == true)
            {
                resourceName = "MakeBackup.TextFiles.BackUp_month.sql";
            }

            string sqlFileContent;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        try
                        {
                            sqlFileContent = sr.ReadToEnd();
                            //MessageBox.Show(sqlFileContent);
                            sqlFileContent = sqlFileContent.Replace("TARGETDB", mainWindow.txbDB.Text);
                            sqlFileContent = sqlFileContent.Replace("BACKUPPATH", mainWindow.txbPath.Text);
                            //MessageBox.Show(sqlFileContent);

                            string sqlFilePath = mainWindow.txbPath.Text + @"\BackUp.sql";
                            System.Text.Encoding sqlEnc = System.Text.Encoding.GetEncoding("UTF-8");
                            System.IO.File.WriteAllText(sqlFilePath, sqlFileContent, sqlEnc);

                            result = true;
                            return result;
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "SQLファイルの作成に失敗しました。", MessageBoxButton.OK, MessageBoxImage.Error);
                            result = false;
                            return result;
                        }

                    }
                }
            }

            return result;
        }
        
    }
}
