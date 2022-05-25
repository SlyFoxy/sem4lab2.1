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
using System.Windows.Shapes;

namespace sem4lab2._1
{
    /// <summary>
    /// Логика взаимодействия для AdminTab.xaml
    /// </summary>
    public partial class AdminTab : Window
    {
        Admin admin;
        ApplicationContext context;
        public AdminTab(Admin admin)
        {
            this.admin = admin;
            this.context = new ApplicationContext();

            InitializeComponent();

            _ = context.Clients.ToList();
            _ = context.CreditCards.ToList();
            _ = context.Accounts.ToList();

            CardList.ItemsSource = context.CreditCards.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Зміни застосовано", "Інформування", MessageBoxButton.OK, MessageBoxImage.Information);
            context.SaveChanges();
        }
    }
}
