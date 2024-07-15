using Repository.Entities;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RestaurantManagerment.Page
{
    /// <summary>
    /// Interaction logic for TablePage.xaml
    /// </summary>
    public partial class TablePage : System.Windows.Controls.Page
    {
        public Table TableSelected;
        private TableService tableService = new();
        public ObservableCollection<Table> Tables { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public TablePage()
        {
            InitializeComponent();
            ChangeCommand = new RelayCommand<Table>(ChangeCategory);
            DeleteCommand = new RelayCommand<Table>(DeleteCategory);
            DataContext = this;
        }



        private void ChangeCategory(Table item)
        {
            // Logic for changing the category
            var AddCategory = new AddCategoryPage();
            AddCategory.Table = item;
            AddCategory.action = "table";
            AddCategory.ShowDialog();
            GetData();
            //categoryService.UpdateCategory(item);
            //MessageBox.Show("Update Successful");
        }

        private void DeleteCategory(Table item)
        {
            //Categories.Remove(item);
            var dialogResult = MessageBox.Show("Are you sure delete " + item.TableName, "Delete", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.Cancel) return;
            tableService.RemoveTable(item);
            Tables.Remove(item);
            System.Windows.MessageBox.Show("Delete Successful");
        }

        private void dataGridCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection change if necessary
            if (CategoryDataGrid.SelectedItems.Count > 0) TableSelected = (Table)CategoryDataGrid.SelectedItems[0];
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        public void GetData()
        {
            var tablelist = tableService.GetTables();
            Tables = new ObservableCollection<Table>(
                tablelist.Select(c => new Table { TableId = c.TableId, TableName = c.TableName })
            );
            CategoryDataGrid.ItemsSource = tablelist;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var AddCategory = new AddCategoryPage();
            AddCategory.action = "table";
            AddCategory.ShowDialog();
            GetData();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = tableService.GetTablesByName(TableSearch.Text);
            CategoryDataGrid.ItemsSource = data;
        }


    }


}
