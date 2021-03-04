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
    public class SituacaosController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Situacaos
        public ActionResult Index()
        {
            return View(db.SituacaoSet.ToList());
        }

        // GET: Situacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.SituacaoSet.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // GET: Situacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Situacaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.SituacaoSet.Add(situacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(situacao);
        }

        // GET: Situacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.SituacaoSet.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] Situacao situacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(situacao);
        }

        // GET: Situacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situacao situacao = db.SituacaoSet.Find(id);
            if (situacao == null)
            {
                return HttpNotFound();
            }
            return View(situacao);
        }

        // POST: Situacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Situacao situacao = db.SituacaoSet.Find(id);
            db.SituacaoSet.Remove(situacao);
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
