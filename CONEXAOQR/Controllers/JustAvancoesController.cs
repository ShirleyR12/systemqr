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
    public class JustAvancoesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: JustAvancoes
        public ActionResult Index()
        {
            return View(db.JustAvancoSet.ToList());
        }

        // GET: JustAvancoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JustAvanco justAvanco = db.JustAvancoSet.Find(id);
            if (justAvanco == null)
            {
                return HttpNotFound();
            }
            return View(justAvanco);
        }

        // GET: JustAvancoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JustAvancoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,descricao,ativo")] JustAvanco justAvanco)
        {
            if (ModelState.IsValid)
            {
                db.JustAvancoSet.Add(justAvanco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(justAvanco);
        }

        // GET: JustAvancoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JustAvanco justAvanco = db.JustAvancoSet.Find(id);
            if (justAvanco == null)
            {
                return HttpNotFound();
            }
            return View(justAvanco);
        }

        // POST: JustAvancoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,descricao,ativo")] JustAvanco justAvanco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(justAvanco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(justAvanco);
        }

        // GET: JustAvancoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JustAvanco justAvanco = db.JustAvancoSet.Find(id);
            if (justAvanco == null)
            {
                return HttpNotFound();
            }
            return View(justAvanco);
        }

        // POST: JustAvancoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JustAvanco justAvanco = db.JustAvancoSet.Find(id);
            db.JustAvancoSet.Remove(justAvanco);
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
