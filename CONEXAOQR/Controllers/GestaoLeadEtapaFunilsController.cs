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
    public class GestaoLeadEtapaFunilsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: GestaoLeadEtapaFunils
        public ActionResult Index()
        {
            var gestaoLeadEtapaFunilSet = db.GestaoLeadEtapaFunilSet.Include(g => g.EtapaFunil);
            return View(gestaoLeadEtapaFunilSet.ToList());
        }

        // GET: GestaoLeadEtapaFunils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeadEtapaFunil gestaoLeadEtapaFunil = db.GestaoLeadEtapaFunilSet.Find(id);
            if (gestaoLeadEtapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(gestaoLeadEtapaFunil);
        }

        // GET: GestaoLeadEtapaFunils/Create
        public ActionResult Create()
        {
            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome");
            return View();
        }

        // POST: GestaoLeadEtapaFunils/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GestaoLeadsId,EtapaFunilId,dtEntrada")] GestaoLeadEtapaFunil gestaoLeadEtapaFunil)
        {
            if (ModelState.IsValid)
            {
                db.GestaoLeadEtapaFunilSet.Add(gestaoLeadEtapaFunil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome", gestaoLeadEtapaFunil.EtapaFunilId);
            return View(gestaoLeadEtapaFunil);
        }

        // GET: GestaoLeadEtapaFunils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeadEtapaFunil gestaoLeadEtapaFunil = db.GestaoLeadEtapaFunilSet.Find(id);
            if (gestaoLeadEtapaFunil == null)
            {
                return HttpNotFound();
            }
            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome", gestaoLeadEtapaFunil.EtapaFunilId);
            return View(gestaoLeadEtapaFunil);
        }

        // POST: GestaoLeadEtapaFunils/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GestaoLeadsId,EtapaFunilId,dtEntrada")] GestaoLeadEtapaFunil gestaoLeadEtapaFunil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestaoLeadEtapaFunil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EtapaFunilId = new SelectList(db.EtapaFunilSet, "Id", "nome", gestaoLeadEtapaFunil.EtapaFunilId);
            return View(gestaoLeadEtapaFunil);
        }

        // GET: GestaoLeadEtapaFunils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeadEtapaFunil gestaoLeadEtapaFunil = db.GestaoLeadEtapaFunilSet.Find(id);
            if (gestaoLeadEtapaFunil == null)
            {
                return HttpNotFound();
            }
            return View(gestaoLeadEtapaFunil);
        }

        // POST: GestaoLeadEtapaFunils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestaoLeadEtapaFunil gestaoLeadEtapaFunil = db.GestaoLeadEtapaFunilSet.Find(id);
            db.GestaoLeadEtapaFunilSet.Remove(gestaoLeadEtapaFunil);
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
