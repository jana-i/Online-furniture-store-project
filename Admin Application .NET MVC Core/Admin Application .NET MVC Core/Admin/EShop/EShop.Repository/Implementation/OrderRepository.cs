using EShop.Domain;
using EShop.Domain.DomainModels;
using EShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        //public List<Order> getAllOrders()
        //{
        //    return entities
        //        .ToListAsync().Result;
        //}
        public List<Order> getAllOrders()
        {
            return entities
                .Include(z => z.User)
                .Include(z => z.ProductInOrders)
                .Include("ProductInOrders.Product")
                .ToListAsync().Result;
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return entities
               .Include(z => z.User)
               .Include(z => z.ProductInOrders)
               .Include("ProductInOrders.Product")
               .SingleOrDefaultAsync(z => z.Id == model.Id).Result;
        }
    }
}
