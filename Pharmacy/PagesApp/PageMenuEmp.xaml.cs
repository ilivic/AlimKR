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

namespace Pharmacy.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для PageMenuEmp.xaml
    /// </summary>
    public partial class PageMenuEmp : Page
    {
        public PageMenuEmp()
        {
            InitializeComponent();
            this.DataContext = ClassApp.ClassCurrent.CurrentEmp;
        }
        private void ClickExit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверенны, что хотите закрыть приложение?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }

        private void ClickAddDrug(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageAddDrug());
        }

        private void ClickAddCat(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageAddCat());
        }

        private void ClickShowDrug(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageShowDrug());
        }

        private void ClickShowCat(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageShowCat());
        }

        private void ClickAddEmp(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageAddEmp());
        }

        private void ClickShowEmp(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageShowEmp());
        }

        private void ClickSpot(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageSpotSale());
        }
    }
}
