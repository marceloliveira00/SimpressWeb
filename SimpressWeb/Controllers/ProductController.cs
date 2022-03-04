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
        public IActionResult CreateOrUpdate(Product model)
        {
            if (model is null) return View("Error");

            Product product = _db.Products.FirstOrDefault(x => x.Id == model.Id);

            if (product is null)
            {
                _db.Products.Add(model);
                _db.SaveChanges();
            }
            else
            {
                model.ProductCategory = _db.ProductCategories.Find(model.ProductCategoryId);

                _db.Entry(product).State = EntityState.Detached;
                _db.Products.Update(model);
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0) return View("Error");

            Product model = _db.Products.FirstOrDefault(x => x.Id == id);

            return Json(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return NotFound();

            Product product = _db.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
