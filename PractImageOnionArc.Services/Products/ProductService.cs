using Microsoft.AspNetCore.Hosting;
using PractImageOnionArc.Domain.Entities;
using PractImageOnionArc.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PractImageOnionArc.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductService(IProductRepository productRepository, IWebHostEnvironment hostEnvironment)
        {
            _productRepository = productRepository;
            _hostEnvironment = hostEnvironment;
        }

        public Product Add(Product model)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using(var fileStream = new FileStream(path, FileMode.Create))
            {
                 model.ImageFile.CopyToAsync(fileStream);
            }
            model.ProductsImage = fileName;
            return _productRepository.Add(model);
        }

        public Product Edit(Product model)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            var oldPath = string.Empty;
            {
                oldPath = Path.Combine(wwwRootPath + "/images/", model.ProductsImage);
            }
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            string path = Path.Combine(wwwRootPath + "/images/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                model.ImageFile.CopyToAsync(fileStream);
                 if (System.IO.File.Exists(oldPath))
                System.IO.File.Delete(oldPath);
            }

            model.ProductsImage = fileName;
            _productRepository.SaveChanges();
            return model;
        }

        public Product Find(int id)
        {
            return _productRepository.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Remove(Product model)
        {
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "images", model.ProductsImage);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            _productRepository.Remove(model);
        }

        public int SaveChanges()
        {
            return _productRepository.SaveChanges();
        }
    }
}
