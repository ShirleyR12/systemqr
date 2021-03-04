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
    public class CorretorsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Corretors
        public ActionResult Index()
        {
            var corretorSet = db.CorretorSet.Include(c => c.Filial).Include(c => c.Empresa);
            return View(corretorSet.ToList());
        }

        // GET: Corretors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corretor corretor = db.CorretorSet.Find(id);
            if (corretor == null)
            {
                return HttpNotFound();
            }
            return View(corretor);
        }

        // GET: Corretors/Create
        public ActionResult Create()
        {
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome");
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome");
            return View();
        }

        // POST: Corretors/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,telefone,email,dtCadastro,dtNascimento,FilialId,EmpresaId")] Corretor corretor)
        {
            if (ModelState.IsValid)
            {
                corretor.dtCadastro = DateTime.Now;
              //  corretor.FilialId  = 1;
                db.CorretorSet.Add(corretor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", corretor.FilialId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", corretor.EmpresaId);
            return View(corretor);
        }
        //Carrega os dados da combo EMPRESA
        public JsonResult FilialCombo(int Id)
        {
            var filial = db.FilialSet.ToList().Where(p => p.EmpresaId == Id);
            ViewBag.GerenteNome = "GerenteNome";
            ViewBag.DiretorNome = "DiretorNome";

            return Json(new SelectList(filial, "Id", "nome"));
        }

        // GET: Corretors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corretor corretor = db.CorretorSet.Find(id);
            if (corretor == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", corretor.FilialId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", corretor.EmpresaId);
            return View(corretor);
        }

        // POST: Corretors/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,telefone,email,dtCadastro,dtNascimento,FilialId,EmpresaId")] Corretor corretor)
        {
            if (ModelState.IsValid)
            {
                corretor.dtCadastro = DateTime.Now;
                db.Entry(corretor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", corretor.FilialId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", corretor.EmpresaId);
            return View(corretor);
        }

        // GET: Corretors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corretor corretor = db.CorretorSet.Find(id);
            if (corretor == null)
            {
                return HttpNotFound();
            }
            return View(corretor);
        }

        // POST: Corretors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Corretor corretor = db.CorretorSet.Find(id);
            db.CorretorSet.Remove(corretor);
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
