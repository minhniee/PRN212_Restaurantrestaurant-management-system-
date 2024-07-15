using System.Windows;
using Service;

namespace RestaurantManagerment;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly UserService _userService = new();

    public MainWindow()
    {
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        InitializeComponent();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        var userName = UsernameTextBox.Text;
        var password = PasswordBox.Password;
        var user = _userService.IsUserValid(userName, password);
        if (user != null)
        {
            Hide();
            var dashboard = new Dashboard();
            dashboard.User = user;
            dashboard.ShowDialog();
        }
        else
        {
            MessageBox.Show("not ok");
        }
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}