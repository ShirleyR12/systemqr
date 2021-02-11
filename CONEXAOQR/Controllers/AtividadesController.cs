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
    public class AtividadesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Atividades
        public ActionResult Index()
        {
            var atividadesSet = db.AtividadesSet.Include(a => a.TipoAtividade).Include(a => a.Situacao);
            return View(atividadesSet.ToList());
        }

        // GET: Atividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividades atividades = db.AtividadesSet.Find(id);
            if (atividades == null)
            {
                return HttpNotFound();
            }
            return View(atividades);
        }

        // GET: Atividades/Create
        public ActionResult Create()
        {
            ViewBag.TipoAtividadeId = new SelectList(db.TipoAtividadeSet, "Id", "nome");
            ViewBag.SituacaoId = new SelectList(db.SituacaoSet, "Id", "nome");
            return View();
        }

        // POST: Atividades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,data,observacao,TipoAtividadeId,SituacaoId")] Atividades atividades)
        {
            if (ModelState.IsValid)
            {
                db.AtividadesSet.Add(atividades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoAtividadeId = new SelectList(db.TipoAtividadeSet, "Id", "nome", atividades.TipoAtividadeId);
            ViewBag.SituacaoId = new SelectList(db.SituacaoSet, "Id", "nome", atividades.SituacaoId);
            return View(atividades);
        }

        // GET: Atividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividades atividades = db.AtividadesSet.Find(id);
            if (atividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoAtividadeId = new SelectList(db.TipoAtividadeSet, "Id", "nome", atividades.TipoAtividadeId);
            ViewBag.SituacaoId = new SelectList(db.SituacaoSet, "Id", "nome", atividades.SituacaoId);
            return View(atividades);
        }

        // POST: Atividades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,data,observacao,TipoAtividadeId,SituacaoId")] Atividades atividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoAtividadeId = new SelectList(db.TipoAtividadeSet, "Id", "nome", atividades.TipoAtividadeId);
            ViewBag.SituacaoId = new SelectList(db.SituacaoSet, "Id", "nome", atividades.SituacaoId);
            return View(atividades);
        }

        // GET: Atividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividades atividades = db.AtividadesSet.Find(id);
            if (atividades == null)
            {
                return HttpNotFound();
            }
            return View(atividades);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atividades atividades = db.AtividadesSet.Find(id);
            db.AtividadesSet.Remove(atividades);
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
