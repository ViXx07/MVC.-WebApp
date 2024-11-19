using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ItemsController : Controller
    {
        private readonly Data.Context _context;

        public ItemsController(Data.Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Item> items = await _context.Items.ToListAsync();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
