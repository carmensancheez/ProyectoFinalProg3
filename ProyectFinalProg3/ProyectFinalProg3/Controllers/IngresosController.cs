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
    public class IngresosController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: Ingresos
        public ActionResult Index()
        {
            var ingresos = db.Ingresos.Include(i => i.Habitaciones).Include(i => i.Pacientes);
            return View(ingresos.ToList());
        }
        [HttpPost]
        public ActionResult Index(string opcion, string valor)
        {
            if (opcion == "Fecha")
            {
                var ingresos = db.Ingresos.Include(c => c.Habitaciones).Include(c => c.Pacientes).Where(a => a.Fecha_Inicio.Contains(valor));
                return View(ingresos.ToList());

            }
            else if (opcion == "Habitacion")
            {
                int data = (from a in db.Habitaciones
                            where a.Numero == valor
                            select a.Id).SingleOrDefault();

                var ingresos = db.Ingresos.Include(i => i.Habitaciones).Include(i => i.Pacientes).Where(e => e.Id_Habitacion.Equals(data));
                return View(ingresos.ToList());
            }

            return View();

        }

        public ActionResult Print()
        {
            var print = new ActionAsPdf("Index");
            return print;
        }

        // GET: Ingresos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // GET: Ingresos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Habitacion = new SelectList(db.Habitaciones, "Id", "Id");
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Id");
            return View();
        }

        // POST: Ingresos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Paciente,Id_Habitacion,Fecha_Inicio")] Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Ingresos.Add(ingresos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Habitacion = new SelectList(db.Habitaciones, "Id", "Id", ingresos.Id_Habitacion);
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Cedula", ingresos.Id_Paciente);
            return View(ingresos);
        }

        // GET: Ingresos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Habitacion = new SelectList(db.Habitaciones, "Id", "Id", ingresos.Id_Habitacion);
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Id", ingresos.Id_Paciente);
            return View(ingresos);
        }

        // POST: Ingresos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Paciente,Id_Habitacion,Fecha_Inicio")] Ingresos ingresos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Habitacion = new SelectList(db.Habitaciones, "Id", "Id", ingresos.Id_Habitacion);
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Id", ingresos.Id_Paciente);
            return View(ingresos);
        }

        // GET: Ingresos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresos ingresos = db.Ingresos.Find(id);
            if (ingresos == null)
            {
                return HttpNotFound();
            }
            return View(ingresos);
        }

        // POST: Ingresos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingresos ingresos = db.Ingresos.Find(id);
            db.Ingresos.Remove(ingresos);
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
