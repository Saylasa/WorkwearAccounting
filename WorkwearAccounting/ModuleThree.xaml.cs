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
    /// Interaction logic for ModuleThree.xaml
    /// </summary>
    public partial class ModuleThree : Window
    {
        public ModuleThree()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPersonWindow window = new AddPersonWindow();
            window.Show();

        }

        private void btnSearchP_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpenCard_Click(object sender, RoutedEventArgs e)
        {
            PersonCardWindow window = new PersonCardWindow();
            window.Show();
        }
    }
}
