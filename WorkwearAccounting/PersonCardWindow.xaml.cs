using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WA.BusinessLayer;
using WA.Dto;

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
            window.Load(person);
            window.Show();
        }

        public void Load(PersonDto personDto)
        {
            if (personDto == null)
                return;
            lblClothes.Content = personDto.ClothingSize;
            lblGlove.Content = personDto.SizeGlove;
            lblSex.Content = personDto.Sex;
            lblHead.Content = personDto.SizeHeadDress;
            lblHeigh.Content = personDto.Height;
            lblShoe.Content = personDto.ShoeSize;
            tbName.Text = personDto.Surname + ' ' + personDto.Name + ' ' + personDto.Patronymic;
            tbEmplPosition.Text = personDto.Position.Name;
            tbManufactory.Text = personDto.Position.Manufactory.Name;

            this.FindedIssued = ProcessFactory.GetIssuedProcessDB().SearchIssued(personDto.Id);
            this.dgIssued.ItemsSource = FindedIssued;

            this.FindedNorm = ProcessFactory.GetNormProcessDB().SearchNorm(personDto.Position.Id);
            this.dgNorm.ItemsSource = FindedNorm;

            person = personDto;
        }
        public IList<IssuedDto> FindedIssued;
        public IList<NormDto> FindedNorm;
        private PersonDto person = new PersonDto();

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            IssuedDto item = dgIssued.SelectedItem as IssuedDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
                return;
            ProcessFactory.GetIssuedProcessDB().Delete(item.Id);
            btnRefresh_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            this.FindedIssued = ProcessFactory.GetIssuedProcessDB().SearchIssued(person.Id);
            this.dgIssued.ItemsSource = FindedIssued;

            this.FindedNorm = ProcessFactory.GetNormProcessDB().SearchNorm(person.Position.Id);
            this.dgNorm.ItemsSource = FindedNorm;
        }
    }
}
