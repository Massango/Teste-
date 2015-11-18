using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teste2.Models;

namespace Teste2.Controllers
{
    public class AutorController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        //
        // GET: /Autor/

        public ActionResult Index()
        {
            return View(db.Autores.ToList());
        }

        //
        // GET: /Autor/Details/5

        public ActionResult Details(int id = 0)
        {
            Autor autor = db.Autores.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        //
        // GET: /Autor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Autor/Create

        [HttpPost]
        public ActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Autores.Add(autor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autor);
        }

        //
        // GET: /Autor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Autor autor = db.Autores.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        public ActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }

        //
        // GET: /Autor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Autor autor = db.Autores.Find(id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }

        //
        // POST: /Autor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Autor autor = db.Autores.Find(id);
            db.Autores.Remove(autor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}