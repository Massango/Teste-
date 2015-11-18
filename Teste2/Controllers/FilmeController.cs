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
    public class FilmeController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        //
        // GET: /Filme/

        public ActionResult Index()
        {
            var filmes = db.Filmes.Include(f => f.Autores).Include(f => f.Actores).Include(f => f.categoria);
            return View(filmes.ToList());
        }

        //
        // GET: /Filme/Details/5

        public ActionResult Details(int id = 0)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // GET: /Filme/Create

        public ActionResult Create()
        {
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nome");
            ViewBag.ActorID = new SelectList(db.Actores, "ActorID", "NomeActor");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Designacao");
            return View();
        }

        //
        // POST: /Filme/Create

        [HttpPost]
        public ActionResult Create(Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nome", filme.AutorID);
            ViewBag.ActorID = new SelectList(db.Actores, "ActorID", "NomeActor", filme.ActorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Designacao", filme.CategoriaID);
            return View(filme);
        }

        //
        // GET: /Filme/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nome", filme.AutorID);
            ViewBag.ActorID = new SelectList(db.Actores, "ActorID", "NomeActor", filme.ActorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Designacao", filme.CategoriaID);
            return View(filme);
        }

        //
        // POST: /Filme/Edit/5

        [HttpPost]
        public ActionResult Edit(Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorID = new SelectList(db.Autores, "AutorID", "Nome", filme.AutorID);
            ViewBag.ActorID = new SelectList(db.Actores, "ActorID", "NomeActor", filme.ActorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Designacao", filme.CategoriaID);
            return View(filme);
        }

        //
        // GET: /Filme/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        //
        // POST: /Filme/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
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