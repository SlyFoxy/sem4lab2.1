using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Refill.xaml
    /// </summary>
    public partial class Refill : Window
    {
        Client client;

        ApplicationContext context;

        public Refill(Client client, ApplicationContext context)
        {
            InitializeComponent();
            this.client = client;
            this.context = context;
            //CreditList.ItemsSource = new ObservableCollection<CreditCard>(client.Account.CreditCards);
            CreditList.ItemsSource = new BindingList<CreditCard>(client.Account.CreditCards.Where(x => !x.IsBlocked).ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CreditList.SelectedItem == null)
            {
                MessageBox.Show("Не вибрано карту", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error); return;
            }
            if (transferBox2.Text != "")
            {
                float transferValue;
                if(!float.TryParse(transferBox2.Text,out transferValue))
                {
                    MessageBox.Show("Введено не число", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);return;
                }
                CreditCard creditCard = CreditList.SelectedItem as CreditCard;

                creditCard.CardBalance += transferValue;

                MessageBox.Show("Операція проведена успішно", "Інформування",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                CreditList.Items.Refresh();
               
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
