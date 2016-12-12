using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WA.BusinessLayer;
using WA.Dto;

namespace WorkwearAccounting
{
    /// <summary>
    /// Interaction logic for SearchNormWindow.xaml
    /// </summary>
    public partial class SearchNormWindow : Window
    {
        public SearchNormWindow()
        {
            InitializeComponent();
            cbEmplPosition.ItemsSource = (from a in EmplPosition orderby a.Name select a).ToList<EmplPositionDto>();
        }

        public IList<NormDto> FindedNorm;
        public bool exec;
        private readonly IList<EmplPositionDto> EmplPosition = ProcessFactory.GetEmplPositionProcessDB().GetList();

        private void CloseForm(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            EmplPositionDto i = (EmplPositionDto)cbEmplPosition.SelectedItem;
            this.FindedNorm = ProcessFactory.GetNormProcessDB().SearchNorm(i.Id);
            this.exec = true;
            this.Close();
        }
    }
}
