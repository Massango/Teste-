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
    public class AluguerController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        //
        // GET: /Aluguer/

        public ActionResult Index()
        {
            var aluguer = db.Aluguer.Include(a => a.Filmes).Include(a => a.Utentes);
            return View(aluguer.ToList());
        }

        //
        // GET: /Aluguer/Details/5

        public ActionResult Details(int id = 0)
        {
            Aluguer aluguer = db.Aluguer.Find(id);
            if (aluguer == null)
            {
                return HttpNotFound();
            }
            return View(aluguer);
        }

        //
        // GET: /Aluguer/Create

        public ActionResult Create()
        {
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo");
            ViewBag.UtenteID = new SelectList(db.Utentes, "UtenteID", "Nome");
            return View();
        }

        //
        // POST: /Aluguer/Create

        [HttpPost]
        public ActionResult Create(Aluguer aluguer)
        {
            if (ModelState.IsValid)
            {
                db.Aluguer.Add(aluguer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo", aluguer.FilmeID);
            ViewBag.UtenteID = new SelectList(db.Utentes, "UtenteID", "Nome", aluguer.UtenteID);
            return View(aluguer);
        }

        //
        // GET: /Aluguer/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Aluguer aluguer = db.Aluguer.Find(id);
            if (aluguer == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo", aluguer.FilmeID);
            ViewBag.UtenteID = new SelectList(db.Utentes, "UtenteID", "Nome", aluguer.UtenteID);
            return View(aluguer);
        }

        //
        // POST: /Aluguer/Edit/5

        [HttpPost]
        public ActionResult Edit(Aluguer aluguer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluguer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeID", "Titulo", aluguer.FilmeID);
            ViewBag.UtenteID = new SelectList(db.Utentes, "UtenteID", "Nome", aluguer.UtenteID);
            return View(aluguer);
        }

        //
        // GET: /Aluguer/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Aluguer aluguer = db.Aluguer.Find(id);
            if (aluguer == null)
            {
                return HttpNotFound();
            }
            return View(aluguer);
        }

        //
        // POST: /Aluguer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluguer aluguer = db.Aluguer.Find(id);
            db.Aluguer.Remove(aluguer);
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