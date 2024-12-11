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
    /// Логика взаимодействия для PageSleepAccessoriesEditAdd.xaml
    /// </summary>
    public partial class PageSleepAccessoriesEditAdd : Page
    {
        private SleepAccessories _currentSleepAccessories = new SleepAccessories();
        public PageSleepAccessoriesEditAdd(SleepAccessories selectedSleepAccessories)
        {
            InitializeComponent();

            if (selectedSleepAccessories == null)
                _currentSleepAccessories = selectedSleepAccessories;

            DataContext = _currentSleepAccessories;
            ComboBrend.ItemsSource = MebelEntities.GetContext().BrendTable.ToList();
            ComboColor.ItemsSource = MebelEntities.GetContext().ColorTable.ToList();
            ComboType.ItemsSource = MebelEntities.GetContext().TypeTable.ToList();
        }
    }
}
