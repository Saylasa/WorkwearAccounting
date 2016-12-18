using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WA.BusinessLayer;
using WA.Dto;

namespace WorkwearAccounting
{
    /// <summary>
    /// Interaction logic for AddWorkwearToPerson.xaml
    /// </summary>
    public partial class AddWorkwearToPerson : Window
    {
        public AddWorkwearToPerson()
        {
            InitializeComponent();
        }

        public void Load(PersonDto personDto)
        {
            if (personDto == null)
                return;
            this.FindedRevenue = ProcessFactory.GetRevenueProcessDB().SearchRevenue();
            this.dgRevenue.ItemsSource = FindedRevenue;
            person = personDto;
        }

        public IList<RevenueDto> FindedRevenue;
        private PersonDto person = new PersonDto();

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (dgRevenue.SelectedItem == null)
            {
                MessageBox.Show("Выберете запись");
                return;
            }
            IssuedDto issuedDto = new IssuedDto
            {
                Revenue = (RevenueDto) dgRevenue.SelectedItem,
                Cancellation = false,
                Date_Issued = DateTime.Now,
                Person = person,
            };

            IssueProcessDB issuedProcessDB = ProcessFactory.GetIssuedProcessDB();
            issuedProcessDB.Add(issuedDto);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
