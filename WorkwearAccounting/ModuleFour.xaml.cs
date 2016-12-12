using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WorkwearAccounting
{
    /// <summary>
    /// Interaction logic for ModuleFour.xaml
    /// </summary>
    public partial class ModuleFour : Window
    {
        public ModuleFour()
        {
            InitializeComponent();
        }

        private void btnOpenRevenue_Click(object sender, RoutedEventArgs e)
        {
            AddRevenueWindow window = new AddRevenueWindow();
            window.Show();
        }
    }
}
