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
    /// Логика взаимодействия для PageSpotSale.xaml
    /// </summary>
    public partial class PageSpotSale : Page
    {
        public static DBApp.Sales sale {  get; set; }
        public PageSpotSale()
        {
            InitializeComponent();
        }

        private void ClickSrc(object sender, RoutedEventArgs e)
        {
            try
            {
                var code = Convert.ToInt32(CodeTB.Text);
                var Sel = App.db.Sales.Where(x => x.id_sale == code && x.DateSale == null).FirstOrDefault();
                if (Sel != null)
                {
                    sale = Sel;
                    this.DataContext = sale;
                    SPSale.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClickSpot(object sender, RoutedEventArgs e)
        {
            try
            {
                sale.DateSale = DateTime.Now;
                sale.Employee = ClassApp.ClassCurrent.CurrentEmp;
                App.db.SaveChanges();
                MessageBox.Show("Выдача зафиксированна");
                NavigationService.Navigate(new PageSpotSale());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
