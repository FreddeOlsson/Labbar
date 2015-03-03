using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using SlumpadeKontakter.Models;
using SlumpadeKontakter.Models.Repository;


namespace SlumpadeKontakter.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository _repository;

        public ContactController()
            : this(new XmlRepository())
        {
        }

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }


        // GET: Contacts
        public ActionResult Index()
        {
            return View(_repository.GetContacts());
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for  
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Email")]Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.AddContact(contact);
                    _repository.Save();

                    TempData["success"] = "Kontakten sparad";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att spara Kontakten. Försök igen!";
            }
            return View(contact);
        }

        // GET: /Contacts/Edit/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }


        // POST /Contacts/Edit/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_POST(Guid id)
        {
            var contactToUpdate = _repository.GetContact(id);

            if (contactToUpdate == null)
            {
                return HttpNotFound();
            }
            if (TryUpdateModel(contactToUpdate, string.Empty, new string[] {"FirstName", "LastName", "Email"}))
            {
                try
                {
                    _repository.UpdateContact(contactToUpdate);
                    _repository.Save();
                    TempData["success"] = "Ändringarna sparade";

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    TempData["error"] = "Misslyckades spara ändringarna. Försök igen!";
                }
            }

            return View(contactToUpdate);
        }


        // GET: /Contacts/Delete/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        public ActionResult Delete(Guid? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contact = _repository.GetContact(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        // POST: /Contact/Delete/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            try
            {
                var contactToDelete = new Contact { ContactId = id };
                _repository.DeleteContact(contactToDelete);
                _repository.Save();
                TempData["success"] = "Kontakten togs bort.";
            }
            catch (Exception)
            {
                TempData["error"] = "Misslyckades att ta bort kontakten. Försök igen!";
                return RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}


