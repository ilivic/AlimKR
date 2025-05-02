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
    /// Логика взаимодействия для PageAddEmp.xaml
    /// </summary>
    public partial class PageAddEmp : Page
    {
        public PageAddEmp()
        {
            InitializeComponent();
        }

        private void ClickAddEmp(object sender, RoutedEventArgs e)
        {
            if (CodeTB.Text != null && NameTB.Text != null)
            {
                var chec = App.db.Employee.Where(x=>x.Code == CodeTB.Text).FirstOrDefault();
                if (chec == null) 
                {
                    App.db.Employee.Add(new DBApp.Employee()
                    {
                        IsActive = true,
                        DataStart = DateTime.Now,
                        Code = CodeTB.Text,
                        FullName = NameTB.Text,
                    });
                    App.db.SaveChanges();
                    MessageBox.Show("Добавление прошло успешно");
                    NavigationService.Navigate(new PageShowEmp());
                }
                else
                {
                    MessageBox.Show("Подобный код неподходит");
                }
            }
        }
    }
}
