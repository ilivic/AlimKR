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
    /// Логика взаимодействия для PageShowBy.xaml
    /// </summary>
    public partial class PageShowBy : Page
    {
        public PageShowBy()
        {
            InitializeComponent();
            ListSale.ItemsSource = App.db.Sales.Where(x=>x.Client_id == ClassApp.ClassCurrent.CurrentCl.id_client && x.DateSale == null).ToList();
        }
    }
}
