using PractImageOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractImageOnionArc.Domain.Repositories
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Add(Product model);
        Product Find(int id);
        void Remove(Product model);
        int SaveChanges();
    }
}
