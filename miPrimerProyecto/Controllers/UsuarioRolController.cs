using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miPrimerProyecto.Models;

namespace miPrimerProyecto.Controllers
{
    public class UsuarioRolController : Controller
    {
        // GET: UsuarioRol
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.usuariorol.ToList());
            }
        }

        public static int nombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idUsuario).id;
            }
        }


        public ActionResult listarUsuario()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public static string nombreRol(int idRol)
        {
            using (var db = new inventario2021Entities())
            {
                return db.roles.Find(idRol).descripcion;
            }
        }


        public ActionResult listarRol()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.roles.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usuariorol newUsuarioRol)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.usuariorol.Add(newUsuarioRol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                usuariorol usuarioRolDetalle = db.usuariorol.Where(u => u.id == id).FirstOrDefault();
                return View(usuarioRolDetalle);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    usuariorol usuarioRol = db.usuariorol.Where(u => u.id == id).FirstOrDefault();
                    return View(usuarioRol);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(usuariorol usuarioRolEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var usuR = db.usuariorol.Find(usuarioRolEdit.id);
                    usuR.idUsuario = usuarioRolEdit.idUsuario;
                    usuR.idRol = usuarioRolEdit.idRol;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    var usuarioRol = db.usuariorol.Find(id);
                    db.usuariorol.Remove(usuarioRol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}