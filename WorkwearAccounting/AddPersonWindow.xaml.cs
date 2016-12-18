using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WA.BusinessLayer;
using WA.Dto;

namespace WorkwearAccounting
{

    /// <summary>
    /// Interaction logic for AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public AddPersonWindow()
        {
            InitializeComponent();
            cbEmplPosition.ItemsSource = (from a in EmplPosition orderby a.Name select a).ToList<EmplPositionDto>();

            cbWorkwearClothes.ItemsSource = ListSizeClothes;
            cbSex.ItemsSource = ListSex;
            cbShoes.ItemsSource = ListShoeSize;

            cbGloves.ItemsSource = ListGloveSize;
            cbHead.ItemsSource = ListHeadSize;
        }

        private readonly IList<EmplPositionDto> EmplPosition = ProcessFactory.GetEmplPositionProcessDB().GetList();
        private readonly List<string> ListSizeClothes = new List<string> { "38", "40-42", "44-46", "48-50", "52-54", "56-58", "60-62" };
        private readonly List<string> ListSex = new List<string> {"М", "Ж"};
        private readonly List<string> ListShoeSize = new List<string> { "48", "50", "51", "52", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47" };
        private readonly List<string> ListGloveSize = new List<string> { "7", "7.5", "8", "8.5", "9", "9.5", "10", "10.5", "11", "11.5", "12" };
        private readonly List<string> ListHeadSize = new List<string> {"55", "56", "57", "58", "59", "60", "61", "62"};

        private int _id;

        public void Load(PersonDto personDto)
        {
            if (personDto == null)
                return;
            _id = personDto.Id;
            cbEmplPosition.Text = personDto.Position.Name;
            cbSex.Text = personDto.Sex;
            cbShoes.Text = personDto.ShoeSize;
            cbWorkwearClothes.Text = personDto.ClothingSize;
            cbGloves.Text = personDto.SizeGlove;
            cbHead.Text = personDto.SizeHeadDress.ToString();

            tbHight.Text = personDto.Height.ToString();
            tbName.Text = personDto.Name;
            tbPatronymic.Text = personDto.Patronymic;
            tbSurname.Text = personDto.Surname;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSurname.Text))
            {
                MessageBox.Show("Введите фамилию!");
                return;
            }
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Введите имя!");
                return;
            }
            if (string.IsNullOrEmpty(tbPatronymic.Text))
            {
                MessageBox.Show("Введите отчество!");
                return;
            }
            decimal res;
            if (!Decimal.TryParse(tbHight.Text, out res))
            {
                MessageBox.Show("Поле рост должно быть корректным! (от 140 до 220 см.)", "Проверка");
                return;
            }
            if (res > 220 || res < 140)
            {
                MessageBox.Show("Поле рост должно быть корректным! (от 140 до 220 см.)", "Проверка");
                return;
            }
            if (string.IsNullOrEmpty(cbEmplPosition.Text))
            {
                MessageBox.Show("Укажите должность!");
                return;
            }
            if (string.IsNullOrEmpty(cbSex.Text))
            {
                MessageBox.Show("Укажите пол!");
                return;
            }
            if (string.IsNullOrEmpty(cbShoes.Text))
            {
                MessageBox.Show("Укажите размер обуви!");
                return;
            }
            if (string.IsNullOrEmpty(cbWorkwearClothes.Text))
            {
                MessageBox.Show("Укажите размер одежды!");
                return;
            }
            if (string.IsNullOrEmpty(cbGloves.Text))
            {
                MessageBox.Show("Укажите размер перчаток!");
                return;
            }
            if (string.IsNullOrEmpty(cbHead.Text))
            {
                MessageBox.Show("Укажите обхват головы!");
                return;
            }

            PersonDto personDto = new PersonDto
            {
                Name = tbName.Text,
                Surname = tbSurname.Text,
                Patronymic = tbPatronymic.Text,
                Height = int.Parse(tbHight.Text),
                Sex = cbSex.SelectedItem.ToString(),
                ShoeSize = cbShoes.SelectedItem.ToString(),
                SizeHeadDress = int.Parse(cbHead.SelectedItem.ToString()),
                Position = (EmplPositionDto) this.cbEmplPosition.SelectedItem,
                ClothingSize = cbWorkwearClothes.SelectedItem.ToString(),
                SizeGlove = cbGloves.SelectedItem.ToString(),
            };
            PersonProcessDB personProcessDB = ProcessFactory.GetPersonProcessDB();

            if (_id == 0)
                personProcessDB.Add(personDto);
            else
            {
                personDto.Id = _id;
                personProcessDB.Update(personDto);
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
