using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace MessengerPR7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidUsername(Name.Text) && IsValidIPAddress(IP.Text))
            {
                TcpClient.usersname = Name.Text.Trim();
                TcpClient.ip = IP.Text.Trim();
                UserWindow client = new UserWindow();
                client.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные имя пользователя и IP-адрес!");
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidUsername(Name.Text))
            {
                TcpServer.usersname = Name.Text.Trim();
                AdminWindow admin = new AdminWindow();
                admin.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректное имя пользователя!");
            }
        }

        private bool IsValidUsername(string username)
        {
            return !string.IsNullOrWhiteSpace(username);
        }

        private bool IsValidIPAddress(string ip)
        {
            var ipPattern = @"^(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\." +
                            @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            return Regex.IsMatch(ip, ipPattern);

        }
    }
}
