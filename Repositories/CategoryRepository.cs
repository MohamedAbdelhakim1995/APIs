using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApis.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceEntity context;
        public CategoryRepository(EcommerceEntity context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            Category c = context.category.Include(c=>c.Products).FirstOrDefault(c=> c.Id == id);
            context.category.Remove(c);

            return context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.category.ToList();
        }

        public Category GetById(int id)
        {
            return context.category.Include(c => c.Products).FirstOrDefault(c => c.Id == id);

        }

        public Category GetByName(string name)
        {
            return context.category.FirstOrDefault(c => c.Name == name);
        }

        public int Insert(Category obj)
        {
            context.category.Add(obj);
            return context.SaveChanges();
        }

        public int Update(int id, Category obj)
        {
            Category C = context.category.FirstOrDefault(c => c.Id == id);

            C.Name = obj.Name;

            return context.SaveChanges();
        }
    }
}
