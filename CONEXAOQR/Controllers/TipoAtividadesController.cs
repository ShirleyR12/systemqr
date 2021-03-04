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
    public class TipoAtividadesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: TipoAtividades
        public ActionResult Index()
        {
            return View(db.TipoAtividadeSet.ToList());
        }

        // GET: TipoAtividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAtividade tipoAtividade = db.TipoAtividadeSet.Find(id);
            if (tipoAtividade == null)
            {
                return HttpNotFound();
            }
            return View(tipoAtividade);
        }

        // GET: TipoAtividades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAtividades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome")] TipoAtividade tipoAtividade)
        {
            if (ModelState.IsValid)
            {
                db.TipoAtividadeSet.Add(tipoAtividade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAtividade);
        }

        // GET: TipoAtividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAtividade tipoAtividade = db.TipoAtividadeSet.Find(id);
            if (tipoAtividade == null)
            {
                return HttpNotFound();
            }
            return View(tipoAtividade);
        }

        // POST: TipoAtividades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome")] TipoAtividade tipoAtividade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoAtividade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAtividade);
        }

        // GET: TipoAtividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAtividade tipoAtividade = db.TipoAtividadeSet.Find(id);
            if (tipoAtividade == null)
            {
                return HttpNotFound();
            }
            return View(tipoAtividade);
        }

        // POST: TipoAtividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAtividade tipoAtividade = db.TipoAtividadeSet.Find(id);
            db.TipoAtividadeSet.Remove(tipoAtividade);
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
