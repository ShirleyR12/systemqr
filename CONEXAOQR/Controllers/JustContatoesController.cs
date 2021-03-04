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
    public class JustContatoesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: JustContatoes
        public ActionResult Index()
        {
            return View(db.JustContatoSet.ToList());
        }

        // GET: JustContatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JustContato justContato = db.JustContatoSet.Find(id);
            if (justContato == null)
            {
                return HttpNotFound();
            }
            return View(justContato);
        }

        // GET: JustContatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JustContatoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,ativo,descricao")] JustContato justContato)
        {
            if (ModelState.IsValid)
            {
                db.JustContatoSet.Add(justContato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(justContato);
        }

        // GET: JustContatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JustContato justContato = db.JustContatoSet.Find(id);
            if (justContato == null)
            {
                return HttpNotFound();
            }
            return View(justContato);
        }

        // POST: JustContatoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,ativo,descricao")] JustContato justContato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(justContato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(justContato);
        }

        // GET: JustContatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JustContato justContato = db.JustContatoSet.Find(id);
            if (justContato == null)
            {
                return HttpNotFound();
            }
            return View(justContato);
        }

        // POST: JustContatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JustContato justContato = db.JustContatoSet.Find(id);
            db.JustContatoSet.Remove(justContato);
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
