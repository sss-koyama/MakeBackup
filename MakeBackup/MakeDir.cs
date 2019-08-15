using System;
using System.IO;
using System.Windows;

namespace MakeBackup
{
    class MakeDir
    {
        MainWindow mainWindow = (MainWindow)App.Current.MainWindow;

        public bool MakeDirMethod(string rbt, string path)
        {
            bool result = false;

            switch (rbt)
            {
                case "week":
                    string[] dirNames =
                        {
                            "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa",
                            "1", "6", "11", "16", "21", "26"
                        };

                    try
                    {
                        foreach (string dirName in dirNames)
                        {
                            string dirPath = path + @"\" + dirName;

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



                case "month":

                    for (int dirnum = 1; dirnum <= 31; dirnum++)
                    {
                        string dirPath = path + @"\" + dirnum.ToString();

                        Directory.CreateDirectory(dirPath);


                    }

                    result = true;
                    return result;
                    

            }

            return result;
            
        }

    }
}
