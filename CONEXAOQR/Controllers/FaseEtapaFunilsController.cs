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
    public class FaseEtapaFunilsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: FaseEtapaFunils
        public ActionResult Index()
        {
            var faseEtapaFunilSet = db.FaseEtapaFunilSet.Include(f => f.EtapaFunil);
            return View(faseEtapaFunilSet.ToList());
        }

        // GET: FaseEtapaFunils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaseEtapaFunil faseEtapaFunil = db.FaseEtapaFunilSet.Find(id);
            if (faseEtapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(faseEtapaFunil);
        }

        // GET: FaseEtapaFunils/Create
        public ActionResult Create()
        {
            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome");
            return View();
        }

        // POST: FaseEtapaFunils/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,EtapaFunilId,EtapaFunilId")] FaseEtapaFunil faseEtapaFunil)
        {
            if (ModelState.IsValid)
            {
                db.FaseEtapaFunilSet.Add(faseEtapaFunil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome", faseEtapaFunil.EtapaFunilId);
            return View(faseEtapaFunil);
        }

        // GET: FaseEtapaFunils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaseEtapaFunil faseEtapaFunil = db.FaseEtapaFunilSet.Find(id);
            if (faseEtapaFunil == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome", faseEtapaFunil.EtapaFunilId);
            return View(faseEtapaFunil);
        }

        // POST: FaseEtapaFunils/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,EtapaFunilId,EtapaFunilId")] FaseEtapaFunil faseEtapaFunil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faseEtapaFunil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome", faseEtapaFunil.EtapaFunilId);
            return View(faseEtapaFunil);
        }

        // GET: FaseEtapaFunils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FaseEtapaFunil faseEtapaFunil = db.FaseEtapaFunilSet.Find(id);
            if (faseEtapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(faseEtapaFunil);
        }

        // POST: FaseEtapaFunils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FaseEtapaFunil faseEtapaFunil = db.FaseEtapaFunilSet.Find(id);
            db.FaseEtapaFunilSet.Remove(faseEtapaFunil);
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
