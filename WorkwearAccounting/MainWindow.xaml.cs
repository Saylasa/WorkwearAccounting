using System;
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

namespace WorkwearAccounting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void btnModul1_Click(object sender, RoutedEventArgs e)
        {
            ModulOne window = new ModulOne();
            window.Show();
        }

        private void btnModul2_Click(object sender, RoutedEventArgs e)
        {
            ModuleTwo window = new ModuleTwo();
            window.Show();
        }

        private void btnModul3_Click(object sender, RoutedEventArgs e)
        {
            ModuleThree window = new ModuleThree();
            window.Show();
        }

        private void btnModul4_Click(object sender, RoutedEventArgs e)
        {
            ModuleFour window = new ModuleFour();
            window.Show();
        }
    }
}
