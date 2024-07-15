using Repository.Entities;

namespace Repository;

public class StaffContainer
{
    private RestaurantsManagerV2Context _context;

    public List<Staff> GetStaffs()
    {
        _context = new RestaurantsManagerV2Context();
        return _context.Staff.ToList();
    }


    public void AddStaff(Staff item)
    {
        _context = new RestaurantsManagerV2Context();
        _context.Staff.Add(item);
        _context.SaveChanges();
    }

    public void UpdateStaff(Staff item)
    {
        _context = new RestaurantsManagerV2Context();
        _context.Staff.Update(item);
        _context.SaveChanges();
    }

    public void DeleteStaff(Staff item)
    {
        _context = new RestaurantsManagerV2Context();
        _context.Staff.Remove(item);
        _context.SaveChanges();
    }
}