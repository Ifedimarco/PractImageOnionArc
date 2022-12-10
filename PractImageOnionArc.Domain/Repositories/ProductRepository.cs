using PractImageOnionArc.Domain.Data;
using PractImageOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractImageOnionArc.Domain.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Product Add(Product model)
        {
            var result = _context.Products.Add(model);
            return result.Entity;
        }

        public Product Find(int id)
        {
            var result = _context.Products.Find(id);
            return result;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Remove(Product model)
        {
            _context.Products.Remove(model);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
