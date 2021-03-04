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
    public class TipoContatoesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: TipoContatoes
        public ActionResult Index()
        {
            return View(db.TipoContatoSet.ToList());
        }

        // GET: TipoContatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContato tipoContato = db.TipoContatoSet.Find(id);
            if (tipoContato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContato);
        }

        // GET: TipoContatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoContatoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                db.TipoContatoSet.Add(tipoContato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoContato);
        }

        // GET: TipoContatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContato tipoContato = db.TipoContatoSet.Find(id);
            if (tipoContato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContato);
        }

        // POST: TipoContatoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] TipoContato tipoContato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoContato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoContato);
        }

        // GET: TipoContatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContato tipoContato = db.TipoContatoSet.Find(id);
            if (tipoContato == null)
            {
                return HttpNotFound();
            }
            return View(tipoContato);
        }

        // POST: TipoContatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoContato tipoContato = db.TipoContatoSet.Find(id);
            db.TipoContatoSet.Remove(tipoContato);
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
