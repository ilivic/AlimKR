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
    /// Логика взаимодействия для PageMenuCL.xaml
    /// </summary>
    public partial class PageMenuCL : Page
    {
        public PageMenuCL()
        {
            InitializeComponent();
            this.DataContext = ClassApp.ClassCurrent.CurrentCl;
        }

        private void ClickExit(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверенны, что хотите закрыть приложение?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }
        }

        private void ClickBy(object sender, RoutedEventArgs e)
        {
           SapFrame.NavigationService.Navigate(new PageByDrug());
        }

        private void ClickShowBy(object sender, RoutedEventArgs e)
        {
            SapFrame.NavigationService.Navigate(new PageShowBy());

        }
    }
}
