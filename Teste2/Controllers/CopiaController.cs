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
    public class CopiaController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        //
        // GET: /Copia/

        public ActionResult Index()
        {
            var copias = db.Copias.Include(c => c.filme).Include(c => c.estado);
            return View(copias.ToList());
        }

        //
        // GET: /Copia/Details/5

        public ActionResult Details(int id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        //
        // GET: /Copia/Create

        public ActionResult Create()
        {
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo");
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao");
            return View();
        }

        //
        // POST: /Copia/Create

        [HttpPost]
        public ActionResult Create(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Copias.Add(copia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        //
        // GET: /Copia/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        //
        // POST: /Copia/Edit/5

        [HttpPost]
        public ActionResult Edit(Copia copia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(copia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo", copia.FilmeID);
            ViewBag.EstadoID = new SelectList(db.Estados, "EstadoID", "Designacao", copia.EstadoID);
            return View(copia);
        }

        //
        // GET: /Copia/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Copia copia = db.Copias.Find(id);
            if (copia == null)
            {
                return HttpNotFound();
            }
            return View(copia);
        }

        //
        // POST: /Copia/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Copia copia = db.Copias.Find(id);
            db.Copias.Remove(copia);
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