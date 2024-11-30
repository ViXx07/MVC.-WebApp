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
        [HttpPost]
        public IActionResult Create(Item obj)
        {
            if(obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The name cannot be the same as the desciption.");
            }
            if (ModelState.IsValid)
            {
                _context.Items.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Items");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Item? itemFromDB = _context.Items.Find(id);

            if(itemFromDB == null)
            {
                return NotFound();
            }
            return View(itemFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Item obj)
        {
            if (obj.Name == obj.Description)
            {
                ModelState.AddModelError("name", "The name cannot be the same as the description.");
            }
            if (ModelState.IsValid)
            {
                _context.Items.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index", "Items");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Item? itemFromDB = _context.Items.Find(id);

            if (itemFromDB == null)
            {
                return NotFound();
            }
            return View(itemFromDB);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int id)
        {
            Item? itemFromDB = _context.Items.Find(id);
            if (itemFromDB == null)
            {
                return NotFound();
            }
            _context.Items.Remove(itemFromDB);
            _context.SaveChanges();
            return RedirectToAction("Index", "Items");
            }
    }
}
