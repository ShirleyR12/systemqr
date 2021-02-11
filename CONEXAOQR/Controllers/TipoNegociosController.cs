using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CONEXAOQR.Models;

namespace CONEXAOQR.Controllers
{
    public class TipoNegociosController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: TipoNegocios
        public ActionResult Index()
        {
            return View(db.TipoNegocioSet.ToList());
        }

        // GET: TipoNegocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNegocio tipoNegocio = db.TipoNegocioSet.Find(id);
            if (tipoNegocio == null)
            {
                return HttpNotFound();
            }
            return View(tipoNegocio);
        }

        // GET: TipoNegocios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoNegocios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] TipoNegocio tipoNegocio)
        {
            if (ModelState.IsValid)
            {
                db.TipoNegocioSet.Add(tipoNegocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoNegocio);
        }

        // GET: TipoNegocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNegocio tipoNegocio = db.TipoNegocioSet.Find(id);
            if (tipoNegocio == null)
            {
                return HttpNotFound();
            }
            return View(tipoNegocio);
        }

        // POST: TipoNegocios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] TipoNegocio tipoNegocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoNegocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoNegocio);
        }

        // GET: TipoNegocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoNegocio tipoNegocio = db.TipoNegocioSet.Find(id);
            if (tipoNegocio == null)
            {
                return HttpNotFound();
            }
            return View(tipoNegocio);
        }

        // POST: TipoNegocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoNegocio tipoNegocio = db.TipoNegocioSet.Find(id);
            db.TipoNegocioSet.Remove(tipoNegocio);
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
