using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miPrimerProyecto.Models;

namespace miPrimerProyecto.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.proveedor.ToList());
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.proveedor.Add(proveedor);
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

        public ActionResult Edit(int id)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor findProveedor = db.proveedor.Where(c => c.id == id).FirstOrDefault();
                    return View(findProveedor);
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
        public ActionResult Edit(proveedor proveedorEdit)
        {

            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor prov = db.proveedor.Find(proveedorEdit.id);
                    prov.nombre = proveedorEdit.nombre;
                    prov.direccion = proveedorEdit.direccion;
                    prov.telefono = proveedorEdit.telefono;
                    prov.nombre_contacto = proveedorEdit.nombre_contacto;
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

            try
            {
                using (var db = new inventario2021Entities())
                {
                    proveedor proveedor = db.proveedor.Find(id);
                    return View(proveedor);
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
                    var proveedor = db.proveedor.Find(id);
                    db.proveedor.Remove(proveedor);
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