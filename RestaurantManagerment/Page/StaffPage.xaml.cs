using Repository.Entities;
using Service;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace RestaurantManagerment.Page;

/// <summary>
///     Interaction logic for StaffPage.xaml
/// </summary>
public partial class StaffPage : System.Windows.Controls.Page
{
    private readonly StaffService staffService = new();

    public StaffPage()
    {
        InitializeComponent();
        ChangeCommand = new RelayCommand<Staff>(ChangeStaff);
        DeleteCommand = new RelayCommand<Staff>(DeleteStaff);
        DataContext = this;
    }

    public ObservableCollection<Staff> Staffs { get; set; }
    public ICommand ChangeCommand { get; set; }
    public ICommand DeleteCommand { get; set; }


    private void ChangeStaff(Staff item)
    {
        // Logic for changing the Staff
        var AddStaff = new AddStaff();
        AddStaff.staff = item;
        AddStaff.ShowDialog();
        GetData();
        staffService.UpdateStaff(item);
    }

    private void DeleteStaff(Staff item)
    {
        //Staffs.Remove(item);
        var dialogResult = MessageBox.Show("Are you sure delete ", "Delete",
            MessageBoxButtons.OKCancel);
        if (dialogResult == DialogResult.Cancel) return;
        staffService.RemoveStaff(item);
        Staffs.Remove(item);
        System.Windows.MessageBox.Show("Delete Successful");
        GetData();
    }


    public void GetData()
    {
        var StaffList = staffService.GetStaffs();
        Staffs = new ObservableCollection<Staff>(
            StaffList.Select(c => new Staff { Id = c.Id, Name = c.Name, Phone = c.Phone, Role = c.Role })
        );
        StaffDataGrid.ItemsSource = Staffs;
    }

    private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        var AddStaff = new AddStaff();
        AddStaff.ShowDialog();
        //GetData();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var data = staffService.GetStaffsByName(CatSearch.Text);
        StaffDataGrid.ItemsSource = data;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        GetData();
    }
}