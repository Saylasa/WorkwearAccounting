using System.Windows;
using WA.BusinessLayer;
using WA.Dto;
using System.Linq;
using System.Collections.Generic;



namespace WorkwearAccounting
{
    /// <summary>
    /// Interaction logic for ModulOne.xaml
    /// </summary>
    public partial class ModulOne : Window
    {
        public ModulOne()
        {
            InitializeComponent();
            cbEmplPosition.ItemsSource = (from a in EmplPosition orderby a.Name select a).ToList<EmplPositionDto>();
            dgNorm.ItemsSource = ProcessFactory.GetNormProcessDB().GetList();
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            //dgEmplPosition.ItemsSource = ProcessFactory.GetEmplPositionProcessDB().GetList();
            dgNorm.ItemsSource = ProcessFactory.GetNormProcessDB().GetList();
        }

        private void btnRefreshE_Click(object sender, RoutedEventArgs e)
        {
            dgEmplPosition.ItemsSource = ProcessFactory.GetEmplPositionProcessDB().GetList();
        }

        private void btnRefreshN_Click(object sender, RoutedEventArgs e)
        {
            dgNorm.ItemsSource = ProcessFactory.GetNormProcessDB().GetList();
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

        private void btnEmplPosition_Click(object sender, RoutedEventArgs e)
        {
            dgNorm.Visibility = Visibility.Hidden;
            dgEmplPosition.Visibility = Visibility.Visible;
            btnRefreshE_Click(sender, e);
            this.btnAdd.Visibility = Visibility.Collapsed;
            this.btnEdit.Visibility = Visibility.Hidden;
            this.btnDelete.Visibility = Visibility.Hidden;
            this.btnSearch.Visibility = Visibility.Hidden;
            this.btnRefresh.Visibility = Visibility.Visible;
        }

        private void btnNorm_Click(object sender, RoutedEventArgs e)
        {
            dgNorm.Visibility = Visibility.Visible;
            dgEmplPosition.Visibility = Visibility.Hidden;
            btnRefreshN_Click(sender, e);
            this.btnAdd.Visibility = Visibility.Visible;
            this.btnEdit.Visibility = Visibility.Visible;
            this.btnDelete.Visibility = Visibility.Visible;
            this.btnRefresh.Visibility = Visibility.Visible;
            this.btnSearch.Visibility = Visibility.Visible;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddNormWindow window = new AddNormWindow();
            window.ShowDialog();
            dgNorm.ItemsSource = ProcessFactory.GetNormProcessDB().GetList();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NormDto item = dgNorm.SelectedItem as NormDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для редактирования", "Редактирование");
                return;
            }
            AddNormWindow window = new AddNormWindow();
            window.Load(item);
            window.ShowDialog();
            btnRefreshN_Click(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            NormDto item = dgNorm.SelectedItem as NormDto;
            if (item == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Удаление запчасти");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Удалить норму " + item.WorkwearDirectory.Name + "?", "Удаление нормы", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
                return;
            ProcessFactory.GetNormProcessDB().Delete(item.Id);
            btnRefreshN_Click(sender, e);
        }

        public IList<NormDto> FindedNorm;
        public bool exec;
        private readonly IList<EmplPositionDto> EmplPosition = ProcessFactory.GetEmplPositionProcessDB().GetList();

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            EmplPositionDto i = (EmplPositionDto)cbEmplPosition.SelectedItem;
            this.FindedNorm = ProcessFactory.GetNormProcessDB().SearchNorm(i.Id);
            this.dgNorm.ItemsSource = FindedNorm;
        }
    }
}
