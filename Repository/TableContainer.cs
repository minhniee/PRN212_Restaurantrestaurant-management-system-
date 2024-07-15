using Repository.Entities;

namespace Repository
{
    public class TableContainer
    {
        private RestaurantsManagerV2Context _context;

        public List<Table> GetTables()
        {
            _context = new RestaurantsManagerV2Context();
            return _context.Tables.ToList();
        }

        public void AddTable(Table table)
        {
            _context = new RestaurantsManagerV2Context();
            _context.Tables.Add(table);
            _context.SaveChanges();
        }

        public void UpdateTable(Table table)
        {
            _context = new RestaurantsManagerV2Context();
            _context.Tables.Update(table);
            _context.SaveChanges();
        }

        public void DeleteTable(Table table)
        {
            _context = new RestaurantsManagerV2Context();
            _context.Tables.Remove(table);

        }
    }
}
