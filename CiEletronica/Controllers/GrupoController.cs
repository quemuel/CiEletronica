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
    public class GrupoController : Controller
    {
        private DbContextAdUsuarios db = new DbContextAdUsuarios();

        public ActionResult ListarGrupo()
        {
            var grupos = db.gru_grupo.ToList(); ;
            return View(grupos);
        }

        public ActionResult CadastrarGrupo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarGrupo([Bind(Include="gru_nom_grupo")] gru_grupo grupo)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    db.gru_grupo.Add(grupo);
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    string message = "";
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        }
                    }
                    throw new InvalidOperationException(message);
                }
                return RedirectToAction("ListarGrupo");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AtualizarGrupo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var grupo = db.gru_grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarGrupo([Bind(Include = "gru_id_gru,gru_nom_grupo")] gru_grupo grupo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(grupo).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    string message = "";
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            message = string.Format("{0}: {1}", validationErrors.Entry.Entity.ToString(), validationError.ErrorMessage);
                        }
                    }
                    throw new InvalidOperationException(message);
                }
                return RedirectToAction("ListarGrupo");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ExcluirGrupo(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var grupo = db.gru_grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
        }

        [HttpPost, ActionName("ExcluirGrupo")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirGrupoConfimar(int id)
        {
            var grupo = db.gru_grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            db.gru_grupo.Remove(grupo);
            db.SaveChanges();
            return RedirectToAction("ListarGrupo");
        }

        public ActionResult VisualizarGrupo(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var grupo = db.gru_grupo.Find(id);
            if (grupo == null)
            {
                return HttpNotFound();
            }
            return View(grupo);
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
