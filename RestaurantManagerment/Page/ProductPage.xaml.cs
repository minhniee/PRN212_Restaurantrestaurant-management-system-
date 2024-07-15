using Repository;
using Repository.Entities;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RestaurantManagerment.Page;

/// <summary>
///     Interaction logic for ProductPage.xaml
/// </summary>
public partial class ProductPage : System.Windows.Controls.Page
{
    public Product ProductSelected;
    private readonly ProductService ProductService = new();
    public ProductPage()
    {
        InitializeComponent();
        ChangeCommand = new RelayCommand<Product>(ChangeProduct);
        DeleteCommand = new RelayCommand<Product>(DeleteProduct);
        DataContext = this;
    }

    public ObservableCollection<Product> Categories { get; set; }
    public ICommand ChangeCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    private void ChangeProduct(Product item)
    {
        // Logic for changing the Product
        var AddProduct = new AddProduct();
        AddProduct.product = item;
        AddProduct.ShowDialog();
        GetData();
        //ProductService.UpdateProduct(item);
        //MessageBox.Show("Update Successful");
    }

    private void DeleteProduct(Product item)
    {
        //Categories.Remove(item);
        var dialogResult = MessageBox.Show("Are you sure delete " + item.PName, "Delete", MessageBoxButtons.OKCancel);
        if (dialogResult == DialogResult.Cancel) return;
        ProductService.RemoveProduct(item);
        Categories.Remove(item);
        System.Windows.MessageBox.Show("Delete Successful");
    }

    private void dataGridCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Handle selection change if necessary
        if (ProductDataGrid.SelectedItems.Count > 0) ProductSelected = (Product)ProductDataGrid.SelectedItems[0];
    }


    public void GetData()
    {
        RestaurantsManagerV2Context context = new();
        var productList = from p in context.Products
                          join c in context.Categories on p.CategoryId equals c.CatId
                          select new Product
                          {
                              PId = p.PId,
                              PName = p.PName,
                              PPrice = p.PPrice,
                              CategoryId = p.CategoryId,
                              CategoryName = c.CatName
                          };

        Categories = new ObservableCollection<Product>(productList.ToList());
        ProductDataGrid.ItemsSource = Categories;
    }

    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var AddProduct = new AddProduct();
        AddProduct.ShowDialog();
        GetData();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var data = ProductService.GetProductsByName(CatSearch.Text);
        ProductDataGrid.ItemsSource = data;
    }

    private void Page_Loaded_1(object sender, RoutedEventArgs e)
    {
        GetData();

    }
}