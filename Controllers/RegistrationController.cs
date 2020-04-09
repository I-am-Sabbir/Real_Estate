using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Models;

namespace Real_Estate.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly AppDbContext _context;
        public RegistrationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserReg([Bind("ID,user_name,Password,Type")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Buyer_Builder),user);
            }
            return View(user);
        }


        public IActionResult Buyer_Builder(User user)
        {

            if (user.Type == "Buyer")
            {
                return RedirectToAction(nameof(Buyer_Registration),user);
            }
            else if (user.Type == "Builder")
            {
                return RedirectToAction(nameof(Builder_Registration),user);
            }
            else
                return NotFound();
        }



        public IActionResult Buyer_Registration(User user)
        {
            ViewData["UserId"] = user.ID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buyer_Registration([Bind("userID,Name,Phone,Address,Email")] Buyer buyer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buyer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(buyer);

        }

        public IActionResult Builder_Registration(User user)
        {
            ViewData["UserId"] = user.ID;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Builder_Registration([Bind("UserID,Company_Name,Location,Contact,Email")] Builder builder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(builder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(builder);

        }


    }
}