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
            string tx = "sqlcmd -S ";
            tx = tx + txbSv.Text + " -E -f i:65001 -i " + "\"" + txbPath.Text + "\\" + "Backup.sql\" > \"" + txbPath.Text + @"\Backup.log" + "\"";
            File.WriteAllText(@"C:\Users\X270-01\Desktop\test.bat", tx);
        }
    }
}
