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
    /// Логика взаимодействия для PageAddCat.xaml
    /// </summary>
    public partial class PageAddCat : Page
    {
        public PageAddCat()
        {
            InitializeComponent();
        }

        private void ClickAddCat(object sender, RoutedEventArgs e)
        {
            if (TitleTB.Text != "") 
            {
                try
                {
                    App.db.CategoryProduct.Add(new DBApp.CategoryProduct()
                    {
                        Title = TitleTB.Text,
                    });
                    App.db.SaveChanges();
                    MessageBox.Show("Добавление прошло успешно");
                    NavigationService.Navigate(new PageShowCat());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
