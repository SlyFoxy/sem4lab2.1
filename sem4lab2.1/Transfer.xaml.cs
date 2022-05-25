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
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace sem4lab2._1
{
    /// <summary>
    /// Логика взаимодействия для Transfer.xaml
    /// </summary>
    public partial class Transfer : Window
    {
        Client client;

        ApplicationContext context;

        public Transfer(Client client, ApplicationContext context)
        {
            InitializeComponent();
            this.client = client;
            this.context = context;
            //CreditList.ItemsSource = new ObservableCollection<CreditCard>(client.Account.CreditCards);
            CreditList.ItemsSource =new BindingList<CreditCard>(client.Account.CreditCards.Where(x=>!x.IsBlocked).ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(CreditList.SelectedItem == null)
            {
                MessageBox.Show("Не вибрано карту", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);return;
            }
            if (transferBox1.Text != "" && transferBox2.Text != "")
            {
                float transferValue;
                if (!float.TryParse(transferBox2.Text, out transferValue))
                {
                    MessageBox.Show("Введено не число", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
                CreditCard creditCard = CreditList.SelectedItem as CreditCard;
                if(creditCard.CardBalance<0)
                {
                    if(creditCard.CardBalance<-creditCard.CreditLimit)
                    {
                        MessageBox.Show("Ви вже перевищили кредитний ліміт, карта може бути заблокована адміністратором",
                           "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);                        
                    }
                    else if(creditCard.CardBalance-transferValue>=creditCard.CreditLimit)
                    {
                        MessageBox.Show("Після переказу ваш баланс буде перевищувати кредитний ліміт",
                           "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else if (creditCard.CardBalance - transferValue <0)
                {
                    MessageBox.Show("Після переказу ваш баланс стане від'ємним",
                       "Увага", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                var dialog = MessageBox.Show("Ви впевнені в переказі?","Запитання", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (dialog == MessageBoxResult.Yes)
                {
                    string TransferNumber = transferBox1.Text.Trim();
                    CreditCard transferCard = context.CreditCards.Where(x => x.CardNumber == TransferNumber).FirstOrDefault();
                    if(transferCard == null)
                    {
                        MessageBox.Show("Карту отримувача не знайдено",
                           "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);return;
                    }
                    creditCard.CardBalance -= transferValue;
                    transferCard.CardBalance += transferValue;
                    context.SaveChanges();
                    MessageBox.Show("Операція проведена успішно", "Інформування",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                    CreditList.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Заповніть усі поля!", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
