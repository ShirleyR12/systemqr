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
    public class EmpresasController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Empresas
        public ActionResult Index()
        {
            var empresaSet = db.EmpresaSet.Include(e => e.RedesSociais).Include(e => e.TipoNegocio);
            return View(empresaSet.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.EmpresaSet.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome");
            ViewBag.TipoNegocioId = new SelectList(db.TipoNegocioSet, "Id", "nome");
            return View();
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,cnpj,email,telefone,endereco,nomeFantasia,gerente,diretor,mqi,crm,site,RedesSociaisId,TipoNegocioId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.EmpresaSet.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome", empresa.RedesSociaisId);
            ViewBag.TipoNegocioId = new SelectList(db.TipoNegocioSet, "Id", "nome", empresa.TipoNegocioId);
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.EmpresaSet.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome", empresa.RedesSociaisId);
            ViewBag.TipoNegocioId = new SelectList(db.TipoNegocioSet, "Id", "nome", empresa.TipoNegocioId);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,cnpj,email,telefone,endereco,nomeFantasia,gerente,diretor,mqi,crm,site,RedesSociaisId,TipoNegocioId")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RedesSociaisId = new SelectList(db.RedesSociaisSet, "Id", "nome", empresa.RedesSociaisId);
            ViewBag.TipoNegocioId = new SelectList(db.TipoNegocioSet, "Id", "nome", empresa.TipoNegocioId);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.EmpresaSet.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.EmpresaSet.Find(id);
            db.EmpresaSet.Remove(empresa);
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
