using System;
using System.Linq;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactDbContext _context;

        public ContactController(ContactDbContext context)
        {
            _context = context;
        }

        // GET: /Contact
        public IActionResult Index()
        {
            return View();
        }

        // POST: /Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Veritabanına iletişim bilgilerini kaydet
                    _context.Contacts.Add(contact);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Your contact details have been successfully saved. Thank you!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving contact information: " + ex.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "There are some errors in the form. Please fill in the required fields correctly.";
            }

            return View(contact);
        }
    }
}
