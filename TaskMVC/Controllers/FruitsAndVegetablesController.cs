using TaskMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace TaskMVC.Controllers
{
    public class FruitsAndVegetablesController : Controller
    {
        private readonly FAVDbContext _context = null;

        public FruitsAndVegetablesController()
        {
            _context = new FAVDbContext();
        }

        // GET: FruitsAndVegetables
        public ActionResult Index()
        {
            var products = _context.products.ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = _context.products.Include(p => p.Category).Include(p=>p.PackSize).FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return HttpNotFound();
        }

        public ActionResult Update()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _context.products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                var packs = _context.PackSizes.ToList();
                ViewBag.Packs = packs;
                //return View(product);

                var categories = _context.Categories.ToList();
                ViewBag.categories = categories;
                return View(product);
            }
            return HttpNotFound("Index");
        }

       [HttpPost]
        public ActionResult Edit(Product products)
        {
            if (products != null)
            {
                var fruitInDb = _context.products.Find(products.Id);
                if (fruitInDb != null)
                {
                    fruitInDb.Id = products.Id;
                    fruitInDb.Name = products.Name;
                    fruitInDb.Price = products.Price;
                    fruitInDb.PackSizeId = products.PackSizeId;
                    fruitInDb.Quantity = products.Quantity;
                    fruitInDb.Discount = products.Discount;
                    fruitInDb.TotalPrice = products.TotalPrice;
                    fruitInDb.CategoryId = products.CategoryId;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            var Categories = _context.Categories.ToList();
            ViewBag.Categories = Categories;
            return View(products);
        }
    }
}