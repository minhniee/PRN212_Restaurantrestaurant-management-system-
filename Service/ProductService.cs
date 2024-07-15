using Repository;
using Repository.Entities;

namespace Service;

public class ProductService
{
    ProductContainer container = new ProductContainer();

    public List<Product> GetProducts()
    {
        return container.GetProducts();
    }

    public List<Product> GetProductsByName(string stringSearch)
    {
        var data = container.GetProducts().Where(x => x.PName.Contains(stringSearch));
        return data.ToList();
    }

    public void RemoveProduct(Product category)
    {
        container.DeleteProduct(category);
    }

    public void AddProduct(Product category)
    {
        container.AddProduct(category);
    }

    public void UpdateProduct(Product category)
    {
        container.UpdateProduct(category);
    }
}