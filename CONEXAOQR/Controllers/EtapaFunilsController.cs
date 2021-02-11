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
    public class EtapaFunilsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: EtapaFunils
        public ActionResult Index()
        {
            return View(db.EtapaFunilSet.ToList());
        }

        // GET: EtapaFunils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtapaFunil etapaFunil = db.EtapaFunilSet.Find(id);
            if (etapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(etapaFunil);
        }

        // GET: EtapaFunils/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EtapaFunils/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,porcentagem,cor")] EtapaFunil etapaFunil)
        {
            if (ModelState.IsValid)
            {
                db.EtapaFunilSet.Add(etapaFunil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etapaFunil);
        }

        // GET: EtapaFunils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtapaFunil etapaFunil = db.EtapaFunilSet.Find(id);
            if (etapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(etapaFunil);
        }

        // POST: EtapaFunils/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,porcentagem,cor")] EtapaFunil etapaFunil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapaFunil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etapaFunil);
        }

        // GET: EtapaFunils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EtapaFunil etapaFunil = db.EtapaFunilSet.Find(id);
            if (etapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(etapaFunil);
        }

        // POST: EtapaFunils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EtapaFunil etapaFunil = db.EtapaFunilSet.Find(id);
            db.EtapaFunilSet.Remove(etapaFunil);
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
