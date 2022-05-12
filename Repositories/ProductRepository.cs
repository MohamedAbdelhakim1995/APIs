using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApis.Repositories
{
    public class ProductRepository : IProductRepository
    {
     private readonly   EcommerceEntity context;
        public ProductRepository(EcommerceEntity context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            Product p = context.product.FirstOrDefault(p => p.Id == id);
            context.product.Remove(p);
            return context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.product.ToList();
        }

        public Product GetById(int id)
        {
            return context.product.FirstOrDefault(p => p.Id == id);
       }

        public Product GetByName(string name)
        {
            return context.product.FirstOrDefault(p => p.Name == name);
        }

        public int Insert(Product obj)
        {
            context.product.Add(obj);

            return context.SaveChanges();
        }

        public int Update(int id, Product obj)
        {
            Product p = context.product.FirstOrDefault(c => c.Id == id);

            p.Name = obj.Name;
            p.Price = obj.Price;
            p.Quantity = obj.Quantity;
            p.Discription = obj.Discription;
            p.CategoryId = obj.CategoryId;

            return context.SaveChanges();
        }
    }
}
