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

        private void SendMessage (string message)
        {
            MessageBox.Show(message);
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

            IPrintable printable = client;
            printable.Print(SendMessage);

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

            IPrintable printable = admin;
            printable.Print(SendMessage);

            Admins.Add(admin);
            this.AdminsList.Items.Add(admin);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Client client1 = new Client("Tsal'", "Vitaliy", "Olegovich", "19.11.1990",
                "+380935617360", "AsusGromyako", "PID123456789", 31, "M");

            client1.firstName = "Vitaliyaridze";
            IDrawable printable = client1;

            printable.Print(SendMessage);

            MessageBox.Show(printable[0]);

            printable = client1;

            printable.Print(x => MessageBox.Show(x));

            printable.Draw(printable.PrintContent, SendMessage);
        }
    }
}
