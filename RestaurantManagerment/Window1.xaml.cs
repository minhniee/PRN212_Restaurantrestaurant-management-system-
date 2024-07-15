using System.Windows;
using System.Windows.Controls;

namespace RestaurantManagerment;

/// <summary>
///     Interaction logic for Window1.xaml
/// </summary>
public partial class Window1 : Window
{
    public Window1()
    {
        InitializeComponent();
    }

    private void NavigateToPage(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
            switch (button.Name)
            {
                case "HomeButton":
                    ContentFrame.Navigate(new Uri("Page1.xaml", UriKind.Relative));
                    break;
                case "CategoryButton":
                    ContentFrame.Navigate(new Uri("Page\\CategoryPage.xaml", UriKind.Relative));
                    break;
                case "ProductButton":
                    ContentFrame.Navigate(new Uri("ProductPage.xaml", UriKind.Relative));
                    break;
                case "POSButton":
                    ContentFrame.Navigate(new Uri("POSPage.xaml", UriKind.Relative));
                    break;
                case "StaffButton":
                    ContentFrame.Navigate(new Uri("StaffPage.xaml", UriKind.Relative));
                    break;
                case "TableButton":
                    ContentFrame.Navigate(new Uri("TablePage.xaml", UriKind.Relative));
                    break;
                case "KitchenButton":
                    ContentFrame.Navigate(new Uri("KitchenPage.xaml", UriKind.Relative));
                    break;
                case "SettingsButton":
                    ContentFrame.Navigate(new Uri("SettingsPage.xaml", UriKind.Relative));
                    break;
            }
    }
}