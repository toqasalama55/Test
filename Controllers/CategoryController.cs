using Microsoft.AspNetCore.Mvc;
using Project1.Data;

namespace Project1.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult Index()
        {
            var result = context.Categories.ToList();
            return View(result);
        }
    }
}
