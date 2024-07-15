using Microsoft.Win32;
using Repository.Entities;
using Service;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RestaurantManagerment.Page;

/// <summary>
///     Interaction logic for AddProduct.xaml
/// </summary>
public partial class AddProduct : Window
{
    private readonly CategoryService categoryService = new();

    public AddProduct()
    {
        InitializeComponent();
    }

    public Product product { get; set; } = null;

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // Populate combo box with categories
        CboCat.ItemsSource = categoryService.GetCategories();
        CboCat.DisplayMemberPath = "CatName";
        CboCat.SelectedValuePath = "CatId";

        CboCat.SelectedValue = product.CategoryId;
        TxtPrdName.Text = product.PName;
        TxtPrdPrice.Text = product.PPrice.ToString();

        // Assuming product.ImagePath is a byte array (byte[])
        if (product.PImage != null && product.PImage.Length > 0)
        {
            // Load image from byte array
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.StreamSource = new MemoryStream(product.PImage); // Assuming product.ImagePath is byte[]
            bitmap.EndInit();

            ImgPrd.Source = bitmap;
        }
        else
        {
            // Handle case where no image is available
            ImgPrd.Source = null; // or set a default image placeholder
        }
    }


    private void BtnBrowse_Click(object sender, RoutedEventArgs e)
    {
        var ofd = new OpenFileDialog();
        ofd.Filter = "Images (.jpg, .png)|*.png;*.jpg";

        if (ofd.ShowDialog() == true) // Check for true instead of System.Windows.Forms.DialogResult.OK
        {
            var filePath = ofd.FileName;

            // Create a BitmapImage to load and display the image
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(filePath);
            bitmap.EndInit();

            // Assign the loaded BitmapImage to the Source property of the Image control
            ImgPrd.Source = bitmap;
        }
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (product != null)
        {
            CboCat.Text = product.CategoryName;
            TxtPrdName.Text = product.PName;
            TxtPrdPrice.Text = product.PPrice.ToString();
            ImgPrd.Source = new BitmapImage();
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}