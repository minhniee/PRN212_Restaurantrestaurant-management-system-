using Repository;
using Repository.Entities;

namespace Service;

public class StaffService
{
    StaffContainer container = new StaffContainer();

    public List<Staff> GetStaffs()
    {
        return container.GetStaffs();
    }

    public List<Staff> GetStaffsByName(string stringSearch)
    {
        var data = container.GetStaffs().Where(x => x.Name.Contains(stringSearch));
        return data.ToList();
    }

    public void RemoveStaff(Staff item)
    {
        container.DeleteStaff(item);
    }

    public void AddStaff(Staff item)
    {
        container.AddStaff(item);
    }

    public void UpdateStaff(Staff item)
    {
        container.UpdateStaff(item);
    }
}