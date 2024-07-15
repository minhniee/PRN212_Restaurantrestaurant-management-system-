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
///     Interaction logic for CategoriPage.xaml
/// </summary>
public partial class CategoryPage : System.Windows.Controls.Page
{
    public Category CategorySelected;
    private readonly CategoryService categoryService = new();

    public CategoryPage()
    {
        InitializeComponent();

        ChangeCommand = new RelayCommand<Category>(ChangeCategory);
        DeleteCommand = new RelayCommand<Category>(DeleteCategory);
        DataContext = this;
    }

    public ObservableCollection<Category> Categories { get; set; }
    public ICommand ChangeCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    private void ChangeCategory(Category item)
    {
        // Logic for changing the category
        var AddCategory = new AddCategoryPage();
        AddCategory.Cat = item;
        AddCategory.ShowDialog();
        GetData();
        //categoryService.UpdateCategory(item);
        //MessageBox.Show("Update Successful");
    }

    private void DeleteCategory(Category item)
    {
        //Categories.Remove(item);
        var dialogResult = MessageBox.Show("Are you sure delete " + item.CatName, "Delete", MessageBoxButtons.OKCancel);
        if (dialogResult == DialogResult.Cancel) return;
        categoryService.RemoveCategory(item);
        Categories.Remove(item);
        System.Windows.MessageBox.Show("Delete Successful");
    }

    private void dataGridCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Handle selection change if necessary
        if (CategoryDataGrid.SelectedItems.Count > 0) CategorySelected = (Category)CategoryDataGrid.SelectedItems[0];
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        GetData();
    }

    public void GetData()
    {
        var categoryList = categoryService.GetCategories();
        Categories = new ObservableCollection<Category>(
            categoryList.Select(c => new Category { CatId = c.CatId, CatName = c.CatName })
        );
        CategoryDataGrid.ItemsSource = Categories;
    }

    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var AddCategory = new AddCategoryPage();
        AddCategory.ShowDialog();
        GetData();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var data = categoryService.GetCategoriesByName(CatSearch.Text);
        CategoryDataGrid.ItemsSource = data;
    }
}

public class RelayCommand<T> : ICommand
{
    private readonly Predicate<T> _canExecute;
    private readonly Action<T> _execute;

    public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
