using EcommerceApis.Models;

namespace EcommerceApis.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);

    }
}
