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
    /// Логика взаимодействия для PageShowCat.xaml
    /// </summary>
    public partial class PageShowCat : Page
    {
        public PageShowCat()
        {
            InitializeComponent();
            ListCat.ItemsSource = App.db.CategoryProduct.ToList();
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            MessageBox.Show("Значения зафиксированны");
        }
    }
}
