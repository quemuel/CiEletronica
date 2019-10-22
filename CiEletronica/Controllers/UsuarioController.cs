using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CiEletronica.Models;
using System.Linq.Dynamic;

namespace CiEletronica.Controllers
{
    public class UsuarioController : Controller
    {
        private DbContextAdUsuarios db = new DbContextAdUsuarios();

        //public ActionResult grid()
        //{
        //    var usu_usuario = db.usu_usuario.Include(u => u.gru_grupo).Include(u => u.set_setor);
        //    var query = from u in db.usu_usuario
        //                join s in db.set_setor on u.usu_id_set equals s.set_id_set

        //                select new UsuarioSetor { usu_usuario = u, set_setor = s };
        //    var model = query.ToList();
        //    return View(model);
        //}

        public ActionResult grid(int page = 1, string sort = "usu_dat_cadastro", string sortdir = "desc", string search = "")
        {
            int pageSize = 10;
            int totalRecord = 0;
            if (page < 1) page = 1;
            int skip = (page * pageSize) - pageSize;
            var data = GetUsuarios(search, sort, sortdir, skip, pageSize, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<usu_usuario> GetUsuarios(string search, string sort, string sortdir, int skip, int pageSize, out int totalRecord)
        {
            //var usu_usuario = db.usu_usuario.Include(u => u.gru_grupo).Include(u => u.set_setor);
            var query = (from u in db.usu_usuario
                            //join s in db.set_setor on u.usu_id_set equals s.set_id_set
                            where
                                    u.usu_nom_usuario.Contains(search) ||
                                    u.usu_nom_login.Contains(search) 
                            select u
                        );
            totalRecord = query.Count();

            query = query.OrderBy(sort + " " + sortdir);
            if (pageSize > 0)
            {
                query = query.Skip(skip).Take(pageSize);
            }
            return query.ToList();
        }

        public ActionResult ListarUsuario()
        {
            //var usu_usuario = db.usu_usuario.Include(u => u.gru_grupo).Include(u => u.set_setor);
            var query = from u in db.usu_usuario
                        join s in db.set_setor on u.usu_id_set equals s.set_id_set

                        select new UsuarioSetor { usu_usuario = u, set_setor = s };
            var model = query.ToList();
            return View(model);
        }

        public ActionResult VisualizarUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usu_usuario usu_usuario = db.usu_usuario.Find(id);
            if (usu_usuario == null)
            {
                return HttpNotFound();
            }
            return View(usu_usuario);
        }

        public ActionResult CadastrarUsuario()
        {
            ViewBag.usu_id_gru = new SelectList(db.gru_grupo, "gru_id_gru", "gru_nom_grupo");
            ViewBag.usu_id_set = new SelectList(db.set_setor, "set_id_set", "set_nom_sigla");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarUsuario([Bind(Include = "usu_nom_usuario,usu_nom_login,usu_id_gru,usu_id_set")] usu_usuario usu_usuario)
        {
            if (ModelState.IsValid)
            {
                usu_usuario.usu_dat_cadastro = DateTime.Now;
                usu_usuario.usu_flg_ativo = true;
                usu_usuario.usu_num_senha = usu_usuario.MD5Hash("123456");
                usu_usuario.usu_uui_identificador = Guid.NewGuid().ToString().Replace("-","");
                db.usu_usuario.Add(usu_usuario);
                db.SaveChanges();
                return RedirectToAction("ListarUsuario");
            }

            ViewBag.usu_id_gru = new SelectList(db.gru_grupo, "gru_id_gru", "gru_nom_grupo", usu_usuario.usu_id_gru);
            ViewBag.usu_id_set = new SelectList(db.set_setor, "set_id_set", "set_nom_sigla", usu_usuario.usu_id_set);
            return View(usu_usuario);
        }
        public ActionResult AtualizarUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usu_usuario usu_usuario = db.usu_usuario.Find(id);
            if (usu_usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.usu_id_gru = new SelectList(db.gru_grupo, "gru_id_gru", "gru_nom_grupo", usu_usuario.usu_id_gru);
            ViewBag.usu_id_set = new SelectList(db.set_setor, "set_id_set", "set_nom_sigla", usu_usuario.usu_id_set);
            return View(usu_usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizarUsuario([Bind(Include = "usu_id_usu,usu_nom_usuario,usu_nom_login,usu_id_gru,usu_id_set")] usu_usuario usu_usuario)
        {
            if (ModelState.IsValid)
            {
                usu_usuario usu_usuario_bd = db.usu_usuario.Find(usu_usuario.usu_id_usu);
                if (usu_usuario_bd == null)
                {
                    return HttpNotFound();
                }
                usu_usuario_bd.usu_nom_usuario = usu_usuario.usu_nom_usuario;
                usu_usuario_bd.usu_nom_login = usu_usuario.usu_nom_login;
                usu_usuario_bd.usu_id_gru = usu_usuario.usu_id_gru;
                usu_usuario_bd.usu_id_set = usu_usuario.usu_id_set;
                db.Entry(usu_usuario_bd).Property(x => x.usu_nom_usuario).IsModified = true;
                db.Entry(usu_usuario_bd).Property(x => x.usu_nom_login).IsModified = true;
                db.Entry(usu_usuario_bd).Property(x => x.usu_id_gru).IsModified = true;
                db.Entry(usu_usuario_bd).Property(x => x.usu_id_set).IsModified = true;
                try
                {
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
                            message = string.Format("{0}: {1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                        }
                    }
                    throw new InvalidOperationException(message);
                }
                return RedirectToAction("ListarUsuario");
            }
            ViewBag.usu_id_gru = new SelectList(db.gru_grupo, "gru_id_gru", "gru_nom_grupo", usu_usuario.usu_id_gru);
            ViewBag.usu_id_set = new SelectList(db.set_setor, "set_id_set", "set_nom_sigla", usu_usuario.usu_id_set);
            return View(usu_usuario);
        }

        public ActionResult ExcluirUsuario(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usu_usuario usu_usuario = db.usu_usuario.Find(id);
            if (usu_usuario == null)
            {
                return HttpNotFound();
            }
            return View(usu_usuario);
        }

        [HttpPost, ActionName("ExcluirUsuario")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirUsuarioConfirmado(int id)
        {
            usu_usuario usu_usuario = db.usu_usuario.Find(id);
            db.usu_usuario.Remove(usu_usuario);
            db.SaveChanges();
            return RedirectToAction("ListarUsuario");
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
