using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectFinalProg3.Models;

namespace ProyectFinalProg3.Controllers
{
    public class CitasMedicasController : Controller
    {
        private ClinicaContext db = new ClinicaContext();

        // GET: CitasMedicas
        public ActionResult Index()
        {
            var citasMedicas = db.CitasMedicas.Include(c => c.Medicos).Include(c => c.Pacientes);
            return View(citasMedicas.ToList());
        }

        // GET: CitasMedicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            if (citasMedicas == null)
            {
                return HttpNotFound();
            }
            return View(citasMedicas);
        }

        // GET: CitasMedicas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Medico = new SelectList(db.Medicos, "Id", "Id");
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Id");
            return View();
        }

        // POST: CitasMedicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Id_Paciente,Id_Medico,Fecha,Hora")] CitasMedicas citasMedicas)
        {
            if (ModelState.IsValid)
            {
                db.CitasMedicas.Add(citasMedicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Medico = new SelectList(db.Medicos, "Id", "Nombre", citasMedicas.Id_Medico);
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Cedula", citasMedicas.Id_Paciente);
            return View(citasMedicas);
        }

        // GET: CitasMedicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            if (citasMedicas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Medico = new SelectList(db.Medicos, "Id", "Nombre", citasMedicas.Id_Medico);
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Cedula", citasMedicas.Id_Paciente);
            return View(citasMedicas);
        }

        // POST: CitasMedicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Id_Paciente,Id_Medico,Fecha,Hora")] CitasMedicas citasMedicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(citasMedicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Medico = new SelectList(db.Medicos, "Id", "Nombre", citasMedicas.Id_Medico);
            ViewBag.Id_Paciente = new SelectList(db.Pacientes, "Id", "Cedula", citasMedicas.Id_Paciente);
            return View(citasMedicas);
        }

        // GET: CitasMedicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            if (citasMedicas == null)
            {
                return HttpNotFound();
            }
            return View(citasMedicas);
        }

        // POST: CitasMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CitasMedicas citasMedicas = db.CitasMedicas.Find(id);
            db.CitasMedicas.Remove(citasMedicas);
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
