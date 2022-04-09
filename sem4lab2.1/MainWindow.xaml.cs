using System.Collections.Generic;
using System.Windows;

namespace sem4lab2._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Client> Clients { get; set; }
        public List<Admin> Admins { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Clients = new List<Client>();
            Admins = new List<Admin>();
        }

        private void ClientAddButton_Click_1(object sender, RoutedEventArgs e)
        {
            Client client = new Client();
            client.lastName = this.lastName_Copy.Text;
            client.firstName = this.firstName_Copy.Text;
            client.middleName = this.middleName_Copy.Text;
            client.dateOfBirth = this.dateOfBirth_Copy.Text;
            client.telephoneNumber = this.telephoneNumber_Copy.Text;
            client.passportID = this.passportID_Copy.Text;
            client.age = int.Parse(age_Copy.Text);
            client.sex = this.sex_Copy.Text;
            client.company = this.company.Text;

            Clients.Add(client);
            this.ClientsList.Items.Add(client);
        }

        private void AdminAddButton_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            admin.lastName = this.lastName.Text;
            admin.firstName = this.firstName.Text;
            admin.middleName = this.middleName.Text;
            admin.dateOfBirth = this.dateOfBirth.Text;
            admin.telephoneNumber = this.telephoneNumber.Text;
            admin.passportID = this.passportID.Text;
            admin.age = int.Parse(age.Text);
            admin.sex = this.sex.Text;
            admin.adminID = this.adminID.Text;

            Admins.Add(admin);
            this.AdminsList.Items.Add(admin);
        }
    }
}
