using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using miPrimerProyecto.Models;
using System.IO;
using System.Web.Routing;

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
            if (!ModelState.IsValid)
                return View();
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

        public ActionResult uploadCSV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult uploadCSV(HttpPostedFileBase fileForm)
        {
            //String para guardar la ruta
            string filePath = string.Empty;

            //condicion para saber si llego el archivo
            if(fileForm != null)
            {
                //Ruta de la carpeta que garda el archivo
                string path = Server.MapPath("~/Uploads/");

                //Condicion para saber si la ruta de la carpeta existe
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Obtener el nombre del archivo
                filePath = path + Path.GetFileName(fileForm.FileName);
                //Obtener la extencion del archivo
                string extension = Path.GetExtension(fileForm.FileName);

                //Guardar el archivo
                fileForm.SaveAs(filePath);

                string cvsData = System.IO.File.ReadAllText(filePath);
                foreach (String row in cvsData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        var newProveedor = new proveedor
                        {
                            nombre = row.Split(';')[0],
                            direccion = row.Split(';')[1],
                            telefono = row.Split(';')[2],
                            nombre_contacto = row.Split(';')[3],
                        };

                        using (var db = new inventario2021Entities())
                        {
                            db.proveedor.Add(newProveedor);
                            db.SaveChanges();
                        }
                    }
                }
            }
            return View();
        }

        public ActionResult PaginaIndex(int pagina = 1)
        {
            var cantidadRegistros  = 3;
            
            using(var db  = new inventario2021Entities())
            {

                var proveedor = db.proveedor.OrderBy(x => x.id).Skip((pagina - 1) * cantidadRegistros)
                    .Take(cantidadRegistros).ToList();

                var totalRegistros = db.proveedor.Count();
                var modelo = new ProveedorIndex();
                modelo.Proveedor = proveedor;
                modelo.ActualPage = pagina;
                modelo.total = totalRegistros;
                modelo.recortPage = cantidadRegistros;
                modelo.ValuesQueryString = new RouteValueDictionary();

                return View(modelo);

            }
        }
    }
}