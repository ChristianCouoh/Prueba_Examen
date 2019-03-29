using Gestion_Asistencias.Context;
using Gestion_Asistencias.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestion_Asistencias.Controllers
{   /// <summary>
///  Este controlador solo será accesible por un usuario registrado
/// </summary>
    [Authorize]
    public class ProfesorController : Controller
    {
        //Agrego mi clase datastore, y agrego la refenencia a .Context esta, clase hará todas las operaciones propias de la base de datos, por eso suelo llamarle así.
        DataStoreZ db = new DataStoreZ();
        /// <summary>
        /// Agrego un ActionResult, que me devolverá un Json con el listado de profesores que existan en la bd. Esto ya que mi intención es que en la vista index de profesores, 
        /// se despliegue en un tabla del plug in DataTables.Net, para ello, debo agregar la carpeta Models, obtener el listado y darle formato Json
        /// </summary>
        /// <returns>Listado en Json</returns>
        public ActionResult GetList()
        {

            var ProfesoresList = db.Profesoress.ToList<Profesores>();
            return Json(new { data = ProfesoresList }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Creo la vista Index, y configuro para utilizar el plugin Datatables.net 
        /// </summary>
        /// <returns></returns>
        // GET: Profesor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Profesor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profesor/Create
        public ActionResult Create()
        {
            return PartialView();
        }
        /// <summary>
        /// Resibe un objeto profesores, y lo inserta en la bd
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        // POST: Profesor/Create
        [HttpPost]
        public ActionResult Create(Profesores p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Profesoress.Add(p);
                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
                return PartialView();
            }
            catch
            {
                return PartialView();
            }
        }
        // GET: Profesor/Edit/5
        /// <summary>
        /// Si se le manda por GET un id de Profesor, entonces lo busca en la bd y lo devuelve como modelo, con esto se "rellenan" los campos.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int? id)
        {

            if (id != null)
            {
                Profesores p = db.Profesoress.Where(model => model.id == id).FirstOrDefault();
                return PartialView(p);
            }
            else
                return View();
        }
        // POST: Profesor/Edit/5
        /// <summary>
        /// Si envia por post, detecta que sea un modelo valido y lo guarda 
        /// </summary>
        /// <param name="X"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Profesores X)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(X).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(X);

            }
            catch
            {
                return View(X);
            }
        }

       
    /// <summary>
    /// Mando un id, conuslto a la bd, optengo el modelo y luego lo elimino.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

        // GET: Profesor/Delete/5
        public JsonResult Delete(int? id)
        {
            if (id != null)
            {
                Profesores p = db.Profesoress.Where(model => model.id == id).FirstOrDefault();
                db.Profesoress.Remove(p);
                db.SaveChanges();
                //return PartialView(p);
                return Json("Correcto", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }


        }
        // POST: Profesor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Si se accede por GET, se entrega un listado del modelo profesores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult cargaCsv()
        {
            return PartialView(new List<Profesores>());
        }
       /// <summary>
       /// Recorro el archivo, y agrego a una lista los modelos profesor, por ultimo recorro esa lista y lo guardo.
       /// </summary>
       /// <param name="postedFile"></param>
       /// <returns></returns>
        [HttpPost]
        public ActionResult cargaCsv(HttpPostedFileBase postedFile)
        {
            List<Profesores> profesoresList = new List<Profesores>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                string csvData = System.IO.File.ReadAllText(filePath);
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        profesoresList.Add(new Profesores
                        {
                            //  id = Convert.ToInt32(row.Split(',')[0]),
                            Nombre = row.Split(',')[1],
                            Direccion = row.Split(',')[2],
                            Telefono = row.Split(',')[2]
                        });

                    }
                }
                foreach (Profesores c in profesoresList)
                {
                    db.Profesoress.Add(c);
                    db.SaveChanges();
                }


            }


            return PartialView(profesoresList);

        }
        /// <summary>
        /// Descargo el archivo para que el usuario caputre sus datos,
        /// </summary>
        /// <returns></returns>
        public FileResult descarga()
        {
         
            var ruta = Server.MapPath("~/Uploads/carga_Ejemplo.csv");
            return File(ruta, "text/csv","LayOut.csv");

        }
    }
}
