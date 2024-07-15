using Repository.Entities;
using Service;
using System.Data;
using System.Windows;

namespace RestaurantManagerment.Page
{
    /// <summary>
    /// Interaction logic for AddStaff.xaml
    /// </summary>
    public partial class AddStaff : System.Windows.Window
    {
        private StaffService _staffService = new StaffService();
        public Staff staff { get; set; } = null;
        public AddStaff()
        {
            InitializeComponent();
        }

        private void ComboBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Staff newStaff = null;
            if (staff != null)
            {
                newStaff = new Staff
                {
                    Id = staff.Id,
                    Name = StaffName.Text,
                    Phone = StaffPhone.Text,
                    Role = CboRole.Text,
                };
                _staffService.UpdateStaff(newStaff);
                MessageBox.Show("Update successful", "Update Staff", MessageBoxButton.OK);
            }
            else
            {
                newStaff = new Staff
                {
                    Name = StaffName.Text,
                    Phone = StaffPhone.Text,
                    Role = CboRole.Text,
                };
                _staffService.AddStaff(newStaff);
                MessageBox.Show("Add successful", "Add Staff", MessageBoxButton.OK);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var roles = _staffService.GetStaffs().Select(s => s.Role).Distinct().ToList();
            CboRole.ItemsSource = roles;
            //CboRole.DisplayMemberPath = "Role";
            //CboRole.SelectedValuePath = "Role";

            if (staff != null)
            {
                StaffName.Text = staff.Name;
                StaffPhone.Text = staff.Phone;
                CboRole.Text = staff.Role;
            }


        }
    }
}
