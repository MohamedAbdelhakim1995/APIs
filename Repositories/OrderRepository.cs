using EcommerceApis.Interfaces;
using EcommerceApis.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApis.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceEntity context;
        public OrderRepository(EcommerceEntity context)
        {
            this.context = context;
        }
        public int Delete(int id)
        {
            Order p = context.order.FirstOrDefault(p => p.Id == id);
            context.order.Remove(p);
            return context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return context.order.ToList();
        }

        public Order GetById(int id)
        {
            return context.order.FirstOrDefault(p => p.Id == id);
        }

      

        public int Insert(Order obj)
        {
            context.order.Add(obj);

            return context.SaveChanges();
        }

        public int Update(int id, Order obj)
        {
            Order p = context.order.FirstOrDefault(c => c.Id == id);

            p.TotalPayment = obj.TotalPayment;
           

            return context.SaveChanges();
        }
    }
}
