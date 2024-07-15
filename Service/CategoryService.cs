using Repository;
using Repository.Entities;

namespace Service
{
    public class CategoryService
    {
        CategoryContainer container = new CategoryContainer();

        public List<Category> GetCategories()
        {
            return container.GetCategories();
        }

        public List<Category> GetCategoriesByName(string stringSearch)
        {
            var data = container.GetCategories().Where(x => x.CatName.Contains(stringSearch));
            return data.ToList();
        }

        public void RemoveCategory(Category category)
        {
            container.DeleteCategory(category);
        }

        public void AddCategory(Category category)
        {
            container.AddCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            container.UpdateCategory(category);
        }
    }
}
