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
    public class ActorController : Controller
    {
        private ProjectoDB db = new ProjectoDB();

        //
        // GET: /Actor/

        public ActionResult Index()
        {
            return View(db.Actores.ToList());
        }

        //
        // GET: /Actor/Details/5

        public ActionResult Details(int id = 0)
        {
            Actor actor = db.Actores.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // GET: /Actor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Actor/Create

        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actores.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actor);
        }

        //
        // GET: /Actor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Actor actor = db.Actores.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Edit/5

        [HttpPost]
        public ActionResult Edit(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //
        // GET: /Actor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Actor actor = db.Actores.Find(id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        //
        // POST: /Actor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Actor actor = db.Actores.Find(id);
            db.Actores.Remove(actor);
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