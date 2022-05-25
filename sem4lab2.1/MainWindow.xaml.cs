using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace sem4lab2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext applicationContext;    
        public MainWindow()
        {
            InitializeComponent();

            applicationContext = new ApplicationContext();

            _ = applicationContext.Clients.ToList();
            _ = applicationContext.Admins.ToList();
            _ = applicationContext.CreditCards.ToList();
            _ = applicationContext.Accounts.ToList();
            
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true)
            {
                bool res = false;
                Admin adm;
                
                    var q= applicationContext.Admins.Where(x=>x.Login==textBoxAdm1.Text && x.Password==textBoxAdm2.Text);
                    adm = q.FirstOrDefault();
                    res = q.Count() >0;
                
                if (res)
                {
                   
                    AdminTab admWin = new AdminTab(adm);
                    admWin.Owner= this;                    
                    //adm.Text = "Адміністратор";
                    admWin.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Не вірний логін або пароль", "Помилка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (textBoxClient1.Text == "")
                {
                    MessageBox.Show("Немає імені", "Помилка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    bool res = false;
                    Client cl;
                    
                        var q = applicationContext.Clients.Where(x => x.Login == textBoxClient1.Text && x.Password == textBoxClient2.Text);
                        cl = q.FirstOrDefault();
                        res = q.Count() >0;
                    
                    if (res)
                    {
                        
                    }
                    else
                    {
                        Client client = new Client();
                        client.Login = textBoxClient1.Text;
                        client.Password = textBoxClient2.Text;
                        MessageBox.Show("Створено користувача з даним логіном і паролем", "Інфо",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        Random random = new Random();
                        Account account = new Account();
                        account.AccountID = "Acc" + random.Next(10000, 19999).ToString();
                        client.Account = account;
                        account.Client = client;

                        applicationContext.Clients.Add(client);
                        applicationContext.Accounts.Add(account);
                        applicationContext.SaveChanges();
                        cl = client;
                        

                    }
                    ClientTab clWin = new ClientTab(textBoxClient1.Text, textBoxClient2.Text);
                    //cl.Text = "Клієнт: " + textBoxClient1.Text;
                    clWin.ShowDialog();
                }

                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            applicationContext.Dispose();
        }
    }
}
