using PractImageOnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractImageOnionArc.Services.Products
{
   public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Add(Product model);
        Product Edit(Product model);
        Product Find(int id);
        void Remove(Product model);
        int SaveChanges();
    }
}
