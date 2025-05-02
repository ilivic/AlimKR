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
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void ClickRegist(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageReg());
        }

        private void ClickAutho(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == "")
            {
                if (PasswordPB.Password != "")
                {
                    var CurrEmp = App.db.Employee.Where(x=>x.Code==PasswordPB.Password && x.IsActive == true).FirstOrDefault();
                    if (CurrEmp != null)
                    {
                        ClassApp.ClassCurrent.CurrentEmp = CurrEmp;
                        MessageBox.Show($"Добро пожаловать {CurrEmp.FullName}");
                        NavigationService.Navigate(new PageMenuEmp());

                    }
                    else
                    {
                        MessageBox.Show("Данный сотрудник не найден или заблокированн");
                    }
                }
                else
                {
                    MessageBox.Show("Поля не заполнены");
                }
            }
            else 
            {
                var CurrCl = App.db.Client.Where(x => x.Login == LoginTB.Text && x.Password == PasswordPB.Password).FirstOrDefault();
                if (CurrCl!=null)
                {
                    ClassApp.ClassCurrent.CurrentCl = CurrCl;
                        MessageBox.Show($"Добро пожаловать {CurrCl.FullName}");
                        NavigationService.Navigate(new PageMenuCL());
                }
                else
                {
                        MessageBox.Show("Данный пользователь не найден");
                }
            }
        }
    }
}
