using Microsoft.AspNetCore.Mvc;
using Project01.Data;
using Project01.Models;

namespace Project01.Controllers
{
	public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			List<Product> products = _context.Products.ToList();
			return View(products);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Product product)
		{
			_context.Products.Add(product);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
