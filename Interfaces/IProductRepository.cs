using EcommerceApis.Models;

namespace EcommerceApis.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByName(string name);
    }
}
