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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }

        private void ClickRevers(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ClickReg(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text != "" && NameTB.Text != "" && PasswordTB.Text != "")
            {
                try
                {
                    App.db.Client.Add(new DBApp.Client()
                    {
                        FullName = NameTB.Text,
                        Password = PasswordTB.Text,
                        Login = LoginTB.Text,
                    });
                    App.db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
