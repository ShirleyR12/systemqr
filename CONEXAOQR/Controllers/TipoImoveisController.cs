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
    public class TipoImoveisController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: TipoImoveis
        public ActionResult Index()
        {
            return View(db.TipoImoveisSet.ToList());
        }

        // GET: TipoImoveis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImoveis tipoImoveis = db.TipoImoveisSet.Find(id);
            if (tipoImoveis == null)
            {
                return HttpNotFound();
            }
            return View(tipoImoveis);
        }

        // GET: TipoImoveis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoImoveis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,ativo,sigla")] TipoImoveis tipoImoveis)
        {
            if (ModelState.IsValid)
            {
                db.TipoImoveisSet.Add(tipoImoveis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoImoveis);
        }

        // GET: TipoImoveis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImoveis tipoImoveis = db.TipoImoveisSet.Find(id);
            if (tipoImoveis == null)
            {
                return HttpNotFound();
            }
            return View(tipoImoveis);
        }

        // POST: TipoImoveis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,ativo,sigla")] TipoImoveis tipoImoveis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoImoveis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoImoveis);
        }

        // GET: TipoImoveis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoImoveis tipoImoveis = db.TipoImoveisSet.Find(id);
            if (tipoImoveis == null)
            {
                return HttpNotFound();
            }
            return View(tipoImoveis);
        }

        // POST: TipoImoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoImoveis tipoImoveis = db.TipoImoveisSet.Find(id);
            db.TipoImoveisSet.Remove(tipoImoveis);
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
