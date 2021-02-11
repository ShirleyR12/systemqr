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
    public class FilialsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Filials
        public ActionResult Index()
        {
            var filialSet = db.FilialSet.Include(f => f.RedesSociais).Include(f => f.Empresa);
            return View(filialSet.ToList());
        }

        // GET: Filials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.FilialSet.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }

        // GET: Filials/Create
        public ActionResult Create()
        {
            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome");
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome");
            return View();
        }

        // POST: Filials/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,gerente,telefone,endereco,email,mqi,crm,site,RedesSociaisId,EmpresaId")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                db.FilialSet.Add(filial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome", filial.RedesSociaisId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", filial.EmpresaId);
            return View(filial);
        }

        // GET: Filials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.FilialSet.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome", filial.RedesSociaisId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", filial.EmpresaId);
            return View(filial);
        }

        // POST: Filials/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,gerente,telefone,endereco,email,mqi,crm,site,RedesSociaisId,EmpresaId")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome", filial.RedesSociaisId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", filial.EmpresaId);
            return View(filial);
        }

        // GET: Filials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filial filial = db.FilialSet.Find(id);
            if (filial == null)
            {
                return HttpNotFound();
            }
            return View(filial);
        }

        // POST: Filials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filial filial = db.FilialSet.Find(id);
            db.FilialSet.Remove(filial);
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
