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
    /// Interaction logic for PersonCardWindow.xaml
    /// </summary>
    public partial class PersonCardWindow : Window
    {
        public PersonCardWindow()
        {
            InitializeComponent();
        }

        private void btnAddWorkwear_Click(object sender, RoutedEventArgs e)
        {
            AddWorkwearToPerson window = new AddWorkwearToPerson();
            window.Show();
        }

        private void btnAddWorkwear_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
