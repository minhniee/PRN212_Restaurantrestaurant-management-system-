using Repository.Entities;

namespace Repository;

public class ProductContainer
{
    private RestaurantsManagerV2Context _context;

    public List<Product> GetProducts()
    {
        _context = new RestaurantsManagerV2Context();
        return _context.Products.ToList();
    }

    public void AddProduct(Product Product)
    {
        _context = new RestaurantsManagerV2Context();
        _context.Products.Add(Product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product Product)
    {
        _context = new RestaurantsManagerV2Context();
        _context.Products.Update(Product);
        _context.SaveChanges();
    }

    public void DeleteProduct(Product Product)
    {
        _context = new RestaurantsManagerV2Context();
        _context.Products.Remove(Product);
        _context.SaveChanges();
    }
}