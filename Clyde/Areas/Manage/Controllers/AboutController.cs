using Clyde.DAL;
using Clyde.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Clyde.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutController(IWebHostEnvironment env, AppDbContext context)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.About.FirstOrDefault());
        }
        public IActionResult Update()
        {
            return View(_context.About.FirstOrDefault());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(About about)
        {
            About a = _context.About.FirstOrDefault();
            if (about.Image != null)
            {
                if (System.IO.File.Exists(Path.Combine(_env.WebRootPath, "assets", "images", a.ImageUrl)))
                {
                    System.IO.File.Delete(Path.Combine(_env.WebRootPath, "assets", "images", a.ImageUrl));
                }
                string fileName = Guid.NewGuid().ToString() + about.Image.FileName;
                using (FileStream fs = new FileStream(Path.Combine(_env.WebRootPath,"assets","images",fileName),FileMode.Create))
                {
                    about.Image.CopyTo(fs);
                }
                a.ImageUrl = fileName;
            }
            a.Address = about.Address;
            a.Email = about.Email;
            a.FullName= about.FullName;
            a.BirthDay = about.BirthDay;
            a.Description = about.Description;
            a.Phone = about.Phone;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
