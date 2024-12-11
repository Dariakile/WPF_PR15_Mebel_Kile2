using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_PR15_Mebel_Kile2.ApplicationData;

namespace WPF_PR15_Mebel_Kile2.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PageSleepAccessoriesAdd.xaml
    /// </summary>
    public partial class PageSleepAccessoriesAdd : Page
    {
        private SleepAccessories _currentSleepAccessories = new SleepAccessories();
        public PageSleepAccessoriesAdd()
        {
            InitializeComponent();
            DataContext = _currentSleepAccessories; 
            ComboBrend.ItemsSource = MebelEntities.GetContext().BrendTable.ToList();
            ComboColor.ItemsSource = MebelEntities.GetContext().ColorTable.ToList();
            ComboType.ItemsSource = MebelEntities.GetContext().TypeTable.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentSleepAccessories.naimenov))
                errors.AppendLine("Укажите название товара");
            if (_currentSleepAccessories.cena <= 0)
                errors.AppendLine("Цена не может быть меньше или равно 0");
            if (_currentSleepAccessories.BrendTable == null)
                errors.AppendLine("Выберите бренд");
            if (string.IsNullOrWhiteSpace(_currentSleepAccessories.srokdostavki))
                errors.AppendLine("Укажите срок доставки товара");
            if (_currentSleepAccessories.TypeTable == null)
                errors.AppendLine("Выберите тип");
            if (_currentSleepAccessories.ColorTable == null)
                errors.AppendLine("Выберите цвет");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentSleepAccessories.ID == 0)
                MebelEntities.GetContext().SleepAccessories.Add(_currentSleepAccessories);
            try
            {
                MebelEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
