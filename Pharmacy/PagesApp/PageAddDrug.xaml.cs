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
    /// Логика взаимодействия для PageAddDrug.xaml
    /// </summary>
    public partial class PageAddDrug : Page
    {
        public PageAddDrug()
        {
            InitializeComponent();
            CatCmB.ItemsSource = App.db.CategoryProduct.ToList();
        }

        private void ClickAddDrug(object sender, RoutedEventArgs e)
        {
            if (CatCmB.SelectedItem != null)
            {
                try
                {
                    var SelCat = CatCmB.SelectedItem as DBApp.CategoryProduct;
                    if (SelCat != null)
                    {
                        App.db.Product.Add(new DBApp.Product() {
                        Title = TitleTB.Text,
                        Description = DescTB.Text,
                        Count = Convert.ToInt32(CountTB.Text),
                        Price = Convert.ToDecimal(PriceTB.Text),
                        CategoryProduct = SelCat,
                        Employee = ClassApp.ClassCurrent.CurrentEmp,
                        IsActive = true
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Добавление прошло успешно");
                        NavigationService.Navigate(new PageShowDrug());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
