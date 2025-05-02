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
    /// Логика взаимодействия для PageByDrug.xaml
    /// </summary>
    public partial class PageByDrug : Page
    {
        public PageByDrug()
        {
            InitializeComponent();
            CatCmB.ItemsSource = App.db.CategoryProduct.ToList();
            ListDrug.ItemsSource = App.db.Product.Where(x => x.IsActive == true && x.Count>=1).ToList();
        }

        private void ClickSerc(object sender, RoutedEventArgs e)
        {
            var selList = App.db.Product.Where(x => x.IsActive == true && x.Count >= 1).ToList();
            if (TitleTb.Text != "")
            {
                selList = selList.Where(x => x.Title.Contains(TitleTb.Text)).ToList();
            }
            if (CatCmB.SelectedItem != null || CatCmB.SelectedIndex != -1)
            {
                var selFil = CatCmB.SelectedItem as DBApp.CategoryProduct;
                selList = selList.Where(x => x.CategoryProduct_id == selFil.id_CategoryProduct).ToList();
            }
            ListDrug.ItemsSource = null;
            ListDrug.ItemsSource = selList;
        }
        private void ClickDef(object sender, RoutedEventArgs e)
        {
            ListDrug.ItemsSource = null;
            ListDrug.ItemsSource = App.db.Product.Where(x => x.IsActive == true).ToList();
        }

        private void ClickBy(object sender, RoutedEventArgs e)
        {
            try
            {
                var sel = (sender as Button).DataContext as DBApp.Product;
                App.db.Sales.Add(new DBApp.Sales()
                {
                    Product = sel,
                    Count = 1,
                    Cost = sel.Price,
                    Client = ClassApp.ClassCurrent.CurrentCl

                });
                sel.Count -= 1;
                App.db.SaveChanges();
                MessageBox.Show("Заказ оформлен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
