using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
    /// Логика взаимодействия для PageShowDrug.xaml
    /// </summary>
    public partial class PageShowDrug : Page
    {
        public PageShowDrug()
        {
            InitializeComponent();
            CatCmB.ItemsSource = App.db.CategoryProduct.ToList();
            EmpCmB.ItemsSource = App.db.Employee.ToList();
            ListDrug.ItemsSource = App.db.Product.Where(x=>x.IsActive == true).ToList();
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            try
            {
                App.db.SaveChanges();
                MessageBox.Show("Значения зафиксированны");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClickSerc(object sender, RoutedEventArgs e)
        {
            var selList = App.db.Product.Where(x => x.IsActive == true).ToList();
            if (TitleTb.Text != "")
            {
                selList = selList.Where(x=>x.Title.Contains(TitleTb.Text)).ToList();
            }
            if (CatCmB.SelectedItem != null || CatCmB.SelectedIndex != -1)
            {
                var selFil = CatCmB.SelectedItem as DBApp.CategoryProduct;
                selList = selList.Where(x => x.CategoryProduct_id == selFil.id_CategoryProduct).ToList();
            }
            if (EmpCmB.SelectedItem != null || EmpCmB.SelectedIndex!=-1)
            {
                var selFil = EmpCmB.SelectedItem as DBApp.Employee;
                selList = selList.Where(x => x.Employe_id == selFil.id_Employee).ToList();
            }
            ListDrug.ItemsSource = null;
            ListDrug.ItemsSource = selList;
        }
        private void ClickDef(object sender, RoutedEventArgs e)
        {
            ListDrug.ItemsSource = null;
            ListDrug.ItemsSource = App.db.Product.Where(x => x.IsActive == true).ToList();
        }

        private void ClickDel(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверенны, что хотите удалить?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var sel = (sender as Button).DataContext as DBApp.Product;
                sel.IsActive = false;
                App.db.SaveChanges();
                MessageBox.Show("Удаление прошло успешно");
            }
        }

    }
}
