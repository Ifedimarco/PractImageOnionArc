using Microsoft.AspNetCore.Mvc;
using PractImageOnionArc.Domain.Entities;
using PractImageOnionArc.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractImageOnionArc.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var Products = _productService.GetAll();
            return View(Products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            var Product = _productService.Add(model);
            _productService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Product = _productService.Find(id);
            return View(Product);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            var Product = _productService.Find(id);
            Product.ProductsName = model.ProductsName;
            Product.ProductsModel = model.ProductsModel;
            Product.ProductsPrice = model.ProductsPrice;
            Product.ProductsImage = model.ProductsImage;
            Product.ImageFile = model.ImageFile;
            _productService.Edit(Product);
            _productService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Product = _productService.Find(id);
            return View(Product);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var Product = _productService.Find(id);
            _productService.Remove(Product);
            _productService.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Product = _productService.Find(id);
            return View(Product);
        }
    }
}
