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
    public class CanalComunicacaosController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: CanalComunicacaos
        public ActionResult Index()
        {
            return View(db.CanalComunicacaoSet.ToList());
        }

        // GET: CanalComunicacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanalComunicacao canalComunicacao = db.CanalComunicacaoSet.Find(id);
            if (canalComunicacao == null)
            {
                return HttpNotFound();
            }
            return View(canalComunicacao);
        }

        // GET: CanalComunicacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CanalComunicacaos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] CanalComunicacao canalComunicacao)
        {
            if (ModelState.IsValid)
            {
                db.CanalComunicacaoSet.Add(canalComunicacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(canalComunicacao);
        }

        // GET: CanalComunicacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanalComunicacao canalComunicacao = db.CanalComunicacaoSet.Find(id);
            if (canalComunicacao == null)
            {
                return HttpNotFound();
            }
            return View(canalComunicacao);
        }

        // POST: CanalComunicacaos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] CanalComunicacao canalComunicacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canalComunicacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(canalComunicacao);
        }

        // GET: CanalComunicacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CanalComunicacao canalComunicacao = db.CanalComunicacaoSet.Find(id);
            if (canalComunicacao == null)
            {
                return HttpNotFound();
            }
            return View(canalComunicacao);
        }

        // POST: CanalComunicacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CanalComunicacao canalComunicacao = db.CanalComunicacaoSet.Find(id);
            db.CanalComunicacaoSet.Remove(canalComunicacao);
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
