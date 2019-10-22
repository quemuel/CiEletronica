using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiEletronica.Models;

namespace CiEletronica.Controllers
{
    public class GrupoController_ : Controller
    {
        private DbContextAdUsuarios db = new DbContextAdUsuarios();

        // GET: Grupo
        public ActionResult Index()
        {
            return View(db.gru_grupo.ToList());
        }

        // GET: Grupo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gru_grupo gru_grupo = db.gru_grupo.Find(id);
            if (gru_grupo == null)
            {
                return HttpNotFound();
            }
            return View(gru_grupo);
        }

        // GET: Grupo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gru_id_gru,gru_nom_grupo")] gru_grupo gru_grupo)
        {
            if (ModelState.IsValid)
            {
                db.gru_grupo.Add(gru_grupo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gru_grupo);
        }

        // GET: Grupo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gru_grupo gru_grupo = db.gru_grupo.Find(id);
            if (gru_grupo == null)
            {
                return HttpNotFound();
            }
            return View(gru_grupo);
        }

        // POST: Grupo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gru_id_gru,gru_nom_grupo")] gru_grupo gru_grupo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gru_grupo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gru_grupo);
        }

        // GET: Grupo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gru_grupo gru_grupo = db.gru_grupo.Find(id);
            if (gru_grupo == null)
            {
                return HttpNotFound();
            }
            return View(gru_grupo);
        }

        // POST: Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gru_grupo gru_grupo = db.gru_grupo.Find(id);
            db.gru_grupo.Remove(gru_grupo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
