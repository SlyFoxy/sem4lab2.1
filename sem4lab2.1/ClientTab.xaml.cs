using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace sem4lab2._1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ClientTab : Window
    {
        Client client;
        ApplicationContext applicationContext;
        public ClientTab(string login, string password)
        {
            
            InitializeComponent();
            this.applicationContext = new ApplicationContext();

            _ = applicationContext.CreditCards.ToList();
            _ = applicationContext.Clients.ToList();
            _ = applicationContext.Accounts.ToList();

            var q = applicationContext.Clients.Where(x => x.Login == login && x.Password == password);
            this.client = q.FirstOrDefault();

            ClientName.Text = client.FullName;

            CreditList.ItemsSource = client.Account.CreditCards;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PayOrder form = new PayOrder(client,applicationContext);
            form.ShowDialog();
            CreditList.Items.Refresh();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Transfer form = new Transfer(client,applicationContext);
            form.ShowDialog();
            CreditList.Items.Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            applicationContext.SaveChanges();
            MessageBox.Show("Зміни застосовано", "Інформування", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            int q = (int)(client.Account.CreditCards?.Where(x => x.CardBalance < 0).Count());
            if (q > 0)
            {
                MessageBox.Show("Ви не можете анулювати рахунок, поки маєте кредит", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                foreach(CreditCard c in client.Account.CreditCards)
                {
                    applicationContext.CreditCards.Remove(c);
                }
                               
                applicationContext.Accounts.Remove(client.Account);
                applicationContext.Clients.Remove(client);
                
                applicationContext.SaveChanges();
                MessageBox.Show("Рахунок анульовано", "Інформування", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            applicationContext.Dispose();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string[] arr = { "5168", "4123" };
            Random random = new Random();
            string cardnum = arr[random.Next(0, 1)];
            cardnum += " ";
            for(int i=1;i<=3;i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    cardnum += random.Next(0, 9).ToString();
                }
                if(i!=3)cardnum += " ";
            }
            CreditCard creditCard = new CreditCard();
            creditCard.CardNumber = cardnum;
            creditCard.CardExpDate=DateTime.Now+new TimeSpan(365*4,0,0,0);
            creditCard.CardCVV = random.Next(100, 999);

            MessageBox.Show($"Картку успішно отримано\nДані: \nНомер:{cardnum}," +
                $" Дата закінчення строку:{creditCard.CardExpDate.Month}/{creditCard.CardExpDate.Year}\n" +
                $"CVV: {creditCard.CardCVV} ", "Інформування", MessageBoxButton.OK, MessageBoxImage.Information);

            client.Account.CreditCards.Add(creditCard);
            creditCard.Account = client.Account;
            applicationContext.CreditCards.Add(creditCard);
            applicationContext.SaveChanges();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Refill form = new Refill(client, applicationContext);
            form.ShowDialog();
            CreditList.Items.Refresh();
        }

        private void CreditList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
