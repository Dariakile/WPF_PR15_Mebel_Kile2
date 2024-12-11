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
    /// Логика взаимодействия для PageSleepAccessories.xaml
    /// </summary>
    public partial class PageSleepAccessories : Page
    {
        public PageSleepAccessories()
        {
            InitializeComponent();
            DtGridSleepAccessories.ItemsSource = MebelEntities.GetContext().SleepAccessories.ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageSleepAccessoriesAdd());
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MebelEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DtGridSleepAccessories.ItemsSource = MebelEntities.GetContext().SleepAccessories.ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageSleepAccessoriesEditAdd((sender as Button).DataContext as SleepAccessories));
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DtGridSleepAccessories.SelectedItems.Cast<SleepAccessories>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующее {tovarForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MebelEntities.GetContext().SleepAccessories.RemoveRange(tovarForRemoving);
                    MebelEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DtGridSleepAccessories.ItemsSource = MebelEntities.GetContext().SleepAccessories.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
