using Repository.Entities;

namespace Repository
{
    public class CategoryContainer
    {
        private RestaurantsManagerV2Context _context;

        public List<Category> GetCategories()
        {
            _context = new RestaurantsManagerV2Context();
            return _context.Categories.ToList();
        }

        public void AddCategory(Category category)
        {
            _context = new RestaurantsManagerV2Context();
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context = new RestaurantsManagerV2Context();
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            _context = new RestaurantsManagerV2Context();
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
