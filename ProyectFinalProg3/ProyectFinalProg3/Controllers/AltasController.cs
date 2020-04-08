using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectFinalProg3.Models;
using Rotativa;

namespace ProyectFinalProg3.Controllers
{
    public class AltasController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: Altas
        public ActionResult Index()
        {
            var altas = db.Altas.Include(a => a.Ingresos);
            return View(altas.ToList());
        }
        [HttpPost]
        public ActionResult Index(string opcion, string valor)
        {
            if (opcion == "Fecha")
            {
                var altas = db.Altas.Include(c => c.Ingresos).Where(a => a.Fecha_Salida == valor);
                try
                {
                    ViewBag.total = altas.Sum(c => c.Monto_Final);
                    ViewBag.conteo = altas.Count();
                    ViewBag.minimo = altas.Min(c => c.Monto_Final);
                    ViewBag.maximo = altas.Max(c => c.Monto_Final);
                    ViewBag.promedio = altas.Average(c => c.Monto_Final);

                    return View(altas.ToList());
                }
                catch(Exception exception)
                {
                    return View(altas.ToList());
                }

            }

            else if (opcion == "Paciente")
            {

                var altas = db.Altas.Include(c => c.Ingresos).Where(a => a.Nombre_Paciente == valor);

                try
                {
                    ViewBag.total = altas.Sum(c => c.Monto_Final);
                    ViewBag.conteo = altas.Count();
                    ViewBag.minimo = altas.Min(c => c.Monto_Final);
                    ViewBag.maximo = altas.Max(c => c.Monto_Final);
                    ViewBag.promedio = altas.Average(c => c.Monto_Final);

                    return View(altas.ToList());
                }
                catch (Exception exception)
                {
                    return View(altas.ToList());
                }

            }
            return View();

        }

        // GET: Altas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Altas altas = db.Altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            return View(altas);
        }

        // GET: Altas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Ingreso = new SelectList(db.Ingresos, "Id", "Id");
            return View();
        }

        // POST: Altas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Monto,Id_Ingreso,Fecha_Salida,Nombre_Paciente,IumHabitacion,Fecha_Inicio,Monto_Final")] Altas altas)
        {
            if (ModelState.IsValid)
            {
                db.Altas.Add(altas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Ingreso = new SelectList(db.Ingresos, "Id", "Fecha_Inicio", altas.Id_Ingreso);
            return View(altas);
        }

        // GET: Altas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Altas altas = db.Altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Ingreso = new SelectList(db.Ingresos, "Id", "Fecha_Inicio", altas.Id_Ingreso);
            return View(altas);
        }

        // POST: Altas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Monto,Id_Ingreso,Fecha_Salida,Nombre_Paciente,IumHabitacion,Fecha_Inicio,Monto_Final")] Altas altas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(altas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Ingreso = new SelectList(db.Ingresos, "Id", "Fecha_Inicio", altas.Id_Ingreso);
            return View(altas);
        }

        // GET: Altas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Altas altas = db.Altas.Find(id);
            if (altas == null)
            {
                return HttpNotFound();
            }
            return View(altas);
        }

        // POST: Altas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Altas altas = db.Altas.Find(id);
            db.Altas.Remove(altas);
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
        public JsonResult Nombre(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join p in db.Pacientes
                             on i.Id_Paciente equals p.Id
                             where i.Id == clavePaciente
                             select p.Nombre).ToList();
            return Json(duplicado);
        }

        public JsonResult Monto(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join h in db.Habitaciones
                             on i.Id_Habitacion equals h.Id
                             where i.Id == clavePaciente
                             select h.Precio).ToList();
            return Json(duplicado);
        }

        public JsonResult FechaIngreso(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             where i.Id == clavePaciente
                             select i.Fecha_Inicio).ToList();
            return Json(duplicado);
        }

        public JsonResult NumeroHabitacion(int clavePaciente)
        {

            var duplicado = (from i in db.Ingresos
                             join h in db.Habitaciones
                             on i.Id_Habitacion equals h.Id
                             where i.Id == clavePaciente
                             select h.Numero).ToList();

            return Json(duplicado);
        }
    }
}
