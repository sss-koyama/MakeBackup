using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MakeBackup
{
    class MakeDir
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public bool MakeDirMethod()
        {
            bool result = false;

            if (mainWindow.rbtWeek.IsChecked == true)
            {
                string[] dirNames =
                {
                "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa",
                "1", "6", "11", "16", "21", "26"
                };

                try
                {
                    foreach (string dirName in dirNames)
                    {
                        string dirPath = mainWindow.txbPath.Text + @"\" + dirName;

                        Directory.CreateDirectory(dirPath);

                    }

                    result = true;
                    return result;

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "フォルダの作成に失敗しました", MessageBoxButton.OK, MessageBoxImage.Error);
                    result = false;
                    return result;
                }
            }

            else if(mainWindow.rbtMonth.IsChecked == true)
            {
                for(int dirnum = 1; dirnum <= 31; dirnum++)
                {
                    string dirPath = mainWindow.txbPath.Text + @"\" + dirnum.ToString();

                    Directory.CreateDirectory(dirPath);


                }

                result = true;
                return result;
            }

            return result;
            
        }

    }
}
