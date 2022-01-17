using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Japeks.Models;

namespace Japeks.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        Library_Implementation c1 = new Library_Implementation();
        public ActionResult Index(string searchString)
        {

            ModelState.Clear();
            return View(c1.GetBk());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View(c1.GetBk().Find(itemodel => itemodel.id == id));
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Library bkinsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (c1.insertbk(bkinsert))
                    {
                        ViewBag.message = "Record Saved Successfully !";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View(c1.GetBk().Find(itemodel => itemodel.id == id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Library updatebk)
        {
            try
            {
                // TODO: Add update logic here
                c1.editbk(updatebk);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            c1.deletebk(id);
            return RedirectToAction("Index");
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
