using System.Windows;

namespace MakeBackup
{
    /// <summary>
    /// HelpWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class HelpWindow : Window
    {
        public HelpWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
