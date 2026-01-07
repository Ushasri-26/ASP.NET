using Assignment_2.Models;
using Assignment_2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repository;

        public ContactController()
        {
            _repository = new ContactRepository();
        }

        // GET: Contact
        public async Task<ActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public async Task<ActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(contact);
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<ActionResult> Delete(long id)
        {
            var contact = await _repository.GetByIdAsync(id);
            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
