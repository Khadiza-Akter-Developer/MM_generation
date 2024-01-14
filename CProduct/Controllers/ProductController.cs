using CProduct.Data;
using CProduct.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CProduct.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductList = _dbContext.products;

            return View(objProductList);
        }
        //get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (obj.Intereste_Product_Service == obj.Quantity.ToString())
            {
                ModelState.AddModelError("name", "Fill up all the forms");
            }
            if (ModelState.IsValid)
            {
                _dbContext.products.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _dbContext.products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (obj.Intereste_Product_Service == obj.Quantity.ToString())
            {
                ModelState.AddModelError("name", "Updated");
            }
            if (ModelState.IsValid)
            {
                _dbContext.products.Update(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var productFromDb = _dbContext.products.Find(id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbContext.products.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.products.Remove(obj);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");




        }
    }
}
