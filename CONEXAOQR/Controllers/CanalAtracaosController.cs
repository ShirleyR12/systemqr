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
    public class CanalAtracaosController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: CanalAtracaos
        public ActionResult Index()
        {
            return View(db.CanalAtracaoSet.ToList());
        }

        // GET: CanalAtracaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanalAtracao canalAtracao = db.CanalAtracaoSet.Find(id);
            if (canalAtracao == null)
            {
                return HttpNotFound();
            }
            return View(canalAtracao);
        }

        // GET: CanalAtracaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanalAtracaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] CanalAtracao canalAtracao)
        {
            if (ModelState.IsValid)
            {
                db.CanalAtracaoSet.Add(canalAtracao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canalAtracao);
        }

        // GET: CanalAtracaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanalAtracao canalAtracao = db.CanalAtracaoSet.Find(id);
            if (canalAtracao == null)
            {
                return HttpNotFound();
            }
            return View(canalAtracao);
        }

        // POST: CanalAtracaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] CanalAtracao canalAtracao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canalAtracao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canalAtracao);
        }

        // GET: CanalAtracaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanalAtracao canalAtracao = db.CanalAtracaoSet.Find(id);
            if (canalAtracao == null)
            {
                return HttpNotFound();
            }
            return View(canalAtracao);
        }

        // POST: CanalAtracaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CanalAtracao canalAtracao = db.CanalAtracaoSet.Find(id);
            db.CanalAtracaoSet.Remove(canalAtracao);
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
