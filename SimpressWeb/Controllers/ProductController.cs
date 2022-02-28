using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Simpress.Models;
using SimpressWeb.Data;
using System.Collections.Generic;
using System.Linq;

namespace SimpressWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbContextApp _db;

        public ProductController(DbContextApp db) { _db = db; }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Products.Include(x => x.ProductCategory);
            ViewBag.ProductCategory = _db.ProductCategories.ToList();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            _db.Products.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product == null)
                return View("Error");

            _db.Update(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            Product product = _db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            _db.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
