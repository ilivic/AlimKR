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
    /// Логика взаимодействия для PageShowEmp.xaml
    /// </summary>
    public partial class PageShowEmp : Page
    {
        public PageShowEmp()
        {
            InitializeComponent();
            ListEmp.ItemsSource = App.db.Employee.Where(x => x.IsActive == true && x.id_Employee != ClassApp.ClassCurrent.CurrentEmp.id_Employee).ToList();
        }

        private void ClickOff(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Отключить пользователя от системы?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var sel = (sender as Button).DataContext as DBApp.Employee;
                sel.IsActive = false;
                App.db.SaveChanges();
            }
        }
    }
}
