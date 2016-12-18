using System.Windows;
using WA.BusinessLayer;
using WA.Dto;
using System.Linq;
using System.Collections.Generic;

namespace WorkwearAccounting
{
    /// <summary>
    /// Interaction logic for ModuleTwo.xaml
    /// </summary>
    public partial class ModuleTwo : Window
    {
        public ModuleTwo()
        {
            InitializeComponent();
            cbEmplPosition.ItemsSource = (from a in EmplPosition orderby a.Name select a).ToList<EmplPositionDto>();
            cbPerson.ItemsSource = (from a in Person orderby a.Surname select a).ToList<PersonDto>();
            dgPerson.ItemsSource = ProcessFactory.GetPersonProcessDB().GetList();
        }
        public IList<PersonDto> FindedPersonEmpl;
        public bool exec;
        private readonly IList<EmplPositionDto> EmplPosition = ProcessFactory.GetEmplPositionProcessDB().GetList();
        public IList<PersonDto> FindedPersonSurn;
        private readonly IList<PersonDto> Person = ProcessFactory.GetPersonProcessDB().GetList();

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            dgPerson.ItemsSource = ProcessFactory.GetPersonProcessDB().GetList();
        }       

        /// <summary>
        /// Изменение настроек подключения к БД
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDatabase_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow window = new SettingsWindow();
            window.ShowDialog();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPersonWindow window = new AddPersonWindow();
            window.ShowDialog();
            dgPerson.ItemsSource = ProcessFactory.GetPersonProcessDB().GetList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            PersonDto item = dgPerson.SelectedItem as PersonDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            AddPersonWindow window = new AddPersonWindow();
            window.Load(item);
            window.ShowDialog();
            btnRefresh_Click(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonDto item = dgPerson.SelectedItem as PersonDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление физического лица");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
                return;
            ProcessFactory.GetPersonProcessDB().Delete(item.Id);
            btnRefresh_Click(sender, e);
        }

        private void btnSearchP_Click(object sender, RoutedEventArgs e)
        {
            EmplPositionDto i = (EmplPositionDto)cbEmplPosition.SelectedItem;
            this.FindedPersonEmpl = ProcessFactory.GetPersonProcessDB().SearchPersonP(i.Id);
            this.dgPerson.ItemsSource = FindedPersonEmpl;
        }

        private void btnSearchN_Click(object sender, RoutedEventArgs e)
        {
            PersonDto i = (PersonDto)cbPerson.SelectedItem;
            this.FindedPersonSurn = ProcessFactory.GetPersonProcessDB().SearchPersonN(i.Surname);
            this.dgPerson.ItemsSource = FindedPersonSurn;
        }
    }
}
