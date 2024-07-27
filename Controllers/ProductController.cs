using Microsoft.AspNetCore.Mvc;
using Project1.Data;
using Project1.Models;

namespace Project1.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var result = context.Products.ToList();
            return View(result);
        }

        public IActionResult Mobiles()
        {
            var result = context.Products.Where(e => e.CategoryId == 2);
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var result = context.Products.Find(id);
            //var result = context.Products.Where()
            return View(result); 
        }

        public IActionResult CreateNew()
        {
            return View();
        }






        public IActionResult SaveNew(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Mobiles");

        }

        public IActionResult Edit(int id)
        {
            var res = context.Products.Find(id);
            return View(res); 
        }

        public IActionResult SaveEdit(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult NotFound()
        {

            return View();
        }

        public IActionResult Delete (int id)
        {
            var res=context.Products.Find(id);
            if (res != null) { 
            context.Products.Remove(res);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NotFound");
            }
        }
    }
}
