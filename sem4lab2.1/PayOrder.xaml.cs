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
    /// Логика взаимодействия для PayOrder.xaml
    /// </summary>
    public partial class PayOrder : Window
    {
        Client client;

        ApplicationContext context;


        public PayOrder(Client client,ApplicationContext context)
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

            float sum = 0;
            if (Check1.IsChecked == true) sum += float.Parse(CheckVal1.Text);
            if (Check2.IsChecked == true) sum += float.Parse(CheckVal2.Text);
            if (Check3.IsChecked == true) sum += float.Parse(CheckVal3.Text);
            if (Check4.IsChecked == true) sum += float.Parse(CheckVal4.Text);
            if (Check5.IsChecked == true) sum += float.Parse(CheckVal5.Text);

            MessageBox.Show($"Ціна до сплати: {sum} грн",
                      "Інформація", MessageBoxButton.OK, MessageBoxImage.Information);

            CreditCard creditCard = CreditList.SelectedItem as CreditCard;
            if (creditCard.CardBalance < 0)
            {
                if (creditCard.CardBalance < -creditCard.CreditLimit)
                {
                    MessageBox.Show("Ви вже перевищили кредитний ліміт, карта може бути заблокована адміністратором",
                       "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (creditCard.CardBalance - sum >= creditCard.CreditLimit)
                {
                    MessageBox.Show("Після оплати ваш баланс буде перевищувати кредитний ліміт",
                       "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (creditCard.CardBalance - sum < 0)
            {
                MessageBox.Show("Після оплати ваш баланс стане від'ємним",
                   "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            var dialog = MessageBox.Show("Ви впевнені в оплаті?", "Запитання", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (dialog == MessageBoxResult.Yes)
            {
                creditCard.CardBalance -= sum;
                
                context.SaveChanges();
                MessageBox.Show("Операція проведена успішно", "Інформування",
                MessageBoxButton.OK, MessageBoxImage.Information);
                CreditList.Items.Refresh();
            }
        }
    }
}

