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
    public class RedesSociaisController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: RedesSociais
        public ActionResult Index()
        {
            return View(db.RedesSociaisSet.ToList());
        }

        // GET: RedesSociais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedesSociais redesSociais = db.RedesSociaisSet.Find(id);
            if (redesSociais == null)
            {
                return HttpNotFound();
            }
            return View(redesSociais);
        }

        // GET: RedesSociais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RedesSociais/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,link")] RedesSociais redesSociais)
        {
            if (ModelState.IsValid)
            {
                db.RedesSociaisSet.Add(redesSociais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(redesSociais);
        }

        // GET: RedesSociais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedesSociais redesSociais = db.RedesSociaisSet.Find(id);
            if (redesSociais == null)
            {
                return HttpNotFound();
            }
            return View(redesSociais);
        }

        // POST: RedesSociais/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,link")] RedesSociais redesSociais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(redesSociais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(redesSociais);
        }

        // GET: RedesSociais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RedesSociais redesSociais = db.RedesSociaisSet.Find(id);
            if (redesSociais == null)
            {
                return HttpNotFound();
            }
            return View(redesSociais);
        }

        // POST: RedesSociais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RedesSociais redesSociais = db.RedesSociaisSet.Find(id);
            db.RedesSociaisSet.Remove(redesSociais);
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
