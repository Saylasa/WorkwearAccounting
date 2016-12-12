using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WA.BusinessLayer;
using WA.Dto;

namespace WorkwearAccounting
{
    public partial class AddNormWindow : Window
    {
        public AddNormWindow()
        {
            InitializeComponent();
            cbEmplPosition.ItemsSource = (from a in EmplPosition orderby a.Name select a).ToList<EmplPositionDto>();
            cbWorkwear.ItemsSource = (from b in Workwear orderby b.Name select b).ToList<WorkwearDirectoryDto>();
        }

        private readonly IList<EmplPositionDto> EmplPosition = ProcessFactory.GetEmplPositionProcessDB().GetList();
        private readonly IList<WorkwearDirectoryDto> Workwear = ProcessFactory.GetWorkwearDirectoryProcessDB().GetList();
        private int _id;

        public void Load(NormDto normDto)
        {
            if (normDto == null)
                return;
            _id = normDto.Id;
            cbEmplPosition.Text = normDto.EmplPosition.Name;
            cbWorkwear.Text = normDto.WorkwearDirectory.Name;
            tbAmount.Text = normDto.Amount.ToString();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAmount.Text))
            {
                MessageBox.Show("Введите количество!");
                return;
            }
            decimal res;
            if (!Decimal.TryParse(tbAmount.Text, out res))
            {
                MessageBox.Show("Поле Цена запчасти может содержать только цифры (32 бита)", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(cbEmplPosition.Text))
            {
                MessageBox.Show("Укажите должность!");
                return;
            }
            if (string.IsNullOrEmpty(cbWorkwear.Text))
            {
                MessageBox.Show("Укажите единицу спецодежды!");
                return;
            }
 
            NormDto normDto = new NormDto
            {
                Amount = int.Parse(tbAmount.Text),
                EmplPosition = (EmplPositionDto)this.cbEmplPosition.SelectedItem,
                WorkwearDirectory = (WorkwearDirectoryDto)this.cbWorkwear.SelectedItem,
            };
            NormProcessDB normProcessDB = ProcessFactory.GetNormProcessDB();

            if (_id == 0)
                normProcessDB.Add(normDto);
            else
            {
                normDto.Id = _id;
                normProcessDB.Update(normDto);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
