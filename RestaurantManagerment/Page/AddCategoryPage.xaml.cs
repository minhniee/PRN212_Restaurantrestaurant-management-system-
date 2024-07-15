using Repository.Entities;
using Service;
using System.Windows;

namespace RestaurantManagerment.Page;

/// <summary>
///     Interaction logic for CategoryPage.xaml
/// </summary>
public partial class AddCategoryPage : Window
{
    private readonly CategoryService categoryService = new();
    private readonly TableService tableService = new();


    public AddCategoryPage()
    {
        InitializeComponent();
    }

    public Category Cat { get; set; } = null;
    public Table Table { get; set; } = null;
    public string action = "";

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (action.Equals("cat"))
        {

            if (Cat == null)
            {
                var category = new Category
                {
                    CatName = CatNameBtn.Text
                };
                categoryService.AddCategory(category);
                MessageBox.Show("Add successful", "Add Category");
            }
            else
            {
                CatNameBtn.Text = Cat.CatName;
                var category = new Category
                {
                    CatId = Cat.CatId,
                    CatName = CatNameBtn.Text
                };
                categoryService.UpdateCategory(category);
                Close();
            }
        }

        if (action.Equals("table"))
        {
            if (Table == null)
            {
                var table = new Table
                {
                    TableName = CatNameBtn.Text
                };
                tableService.AddTable(table);
                MessageBox.Show("Add successful", "Add Category");
            }
            else
            {
                var table = new Table
                {
                    TableId = Table.TableId,
                    TableName = CatNameBtn.Text
                };
                tableService.UpdateTable(table);
                Close();
            }
        }
    }


    private void Cancle_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (Cat != null)
        {
            CatNameBtn.Text = Cat.CatName;

        }

        if (Table != null)
        {
            CatNameBtn.Text = Table.TableName;
        }

    }
}