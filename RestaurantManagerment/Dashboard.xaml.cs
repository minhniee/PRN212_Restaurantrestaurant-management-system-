using System.Windows;
using System.Windows.Controls;
using Repository.Entities;

namespace RestaurantManagerment;

/// <summary>
///     Interaction logic for Dashboard.xaml
/// </summary>
public partial class Dashboard : Window
{
    public Dashboard()
    {
        InitializeComponent();
    }

    public User User { get; set; }

    public static void AddControls()
    {
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        lblUserName.Text = "Welcome, ";
    }

    private void NavigateToPage(object sender, RoutedEventArgs e)
    {
        if (sender is RadioButton radioButton)
            switch (radioButton.Name)
            {
                case "HomeButton":
                    ContentFrame.Navigate(new Uri("Page/HomePage.xaml", UriKind.RelativeOrAbsolute));
                    break;

                case "CategoryButton":
                    ContentFrame.Navigate(new Uri("Page/CategoryPage.xaml", UriKind.Relative));
                    break;
                case "ProductButton":
                    ContentFrame.Navigate(new Uri("Page/ProductPage.xaml", UriKind.Relative));
                    break;
                case "POSButton":
                    ContentFrame.Navigate(new Uri("Page/POSPage.xaml", UriKind.Relative));
                    break;
                case "StaffButton":
                    ContentFrame.Navigate(new Uri("Page/StaffPage.xaml", UriKind.Relative));
                    break;
                case "TableButton":
                    ContentFrame.Navigate(new Uri("Page/TablePage.xaml", UriKind.Relative));
                    break;
                case "KitchenButton":
                    ContentFrame.Navigate(new Uri("Page/KitchenPage.xaml", UriKind.Relative));
                    break;
                case "SettingsButton":
                    ContentFrame.Navigate(new Uri("Page/SettingsPage.xaml", UriKind.Relative));
                    break;
            }
    }
}