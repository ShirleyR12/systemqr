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
    public class GestaoLeadsAtividadesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: GestaoLeadsAtividades
        public ActionResult Index()
        {
            var gestaoLeadsAtividadesSet = db.GestaoLeadsAtividadesSet.Include(g => g.Atividades).Include(g => g.GestaoLeads);
            return View(gestaoLeadsAtividadesSet.ToList());
        }

        // GET: GestaoLeadsAtividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeadsAtividades gestaoLeadsAtividades = db.GestaoLeadsAtividadesSet.Find(id);
            if (gestaoLeadsAtividades == null)
            {
                return HttpNotFound();
            }
            return View(gestaoLeadsAtividades);
        }

        // GET: GestaoLeadsAtividades/Create
        public ActionResult Create()
        {
            ViewBag.AtividadesId = new SelectList(db.AtividadesSet, "Id", "observacao");
            ViewBag.GestaoLeadsId = new SelectList(db.GestaoLeadsSet, "Id", "dtEntrada");
            return View();
        }

        // POST: GestaoLeadsAtividades/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AtividadesId,GestaoLeadsId")] GestaoLeadsAtividades gestaoLeadsAtividades)
        {
            if (ModelState.IsValid)
            {
                db.GestaoLeadsAtividadesSet.Add(gestaoLeadsAtividades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtividadesId = new SelectList(db.AtividadesSet, "Id", "observacao", gestaoLeadsAtividades.AtividadesId);
            ViewBag.GestaoLeadsId = new SelectList(db.GestaoLeadsSet, "Id", "dtEntrada", gestaoLeadsAtividades.GestaoLeadsId);
            return View(gestaoLeadsAtividades);
        }

        // GET: GestaoLeadsAtividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeadsAtividades gestaoLeadsAtividades = db.GestaoLeadsAtividadesSet.Find(id);
            if (gestaoLeadsAtividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtividadesId = new SelectList(db.AtividadesSet, "Id", "observacao", gestaoLeadsAtividades.AtividadesId);
            ViewBag.GestaoLeadsId = new SelectList(db.GestaoLeadsSet, "Id", "dtEntrada", gestaoLeadsAtividades.GestaoLeadsId);
            return View(gestaoLeadsAtividades);
        }

        // POST: GestaoLeadsAtividades/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AtividadesId,GestaoLeadsId")] GestaoLeadsAtividades gestaoLeadsAtividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestaoLeadsAtividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtividadesId = new SelectList(db.AtividadesSet, "Id", "observacao", gestaoLeadsAtividades.AtividadesId);
            ViewBag.GestaoLeadsId = new SelectList(db.GestaoLeadsSet, "Id", "dtEntrada", gestaoLeadsAtividades.GestaoLeadsId);
            return View(gestaoLeadsAtividades);
        }

        // GET: GestaoLeadsAtividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeadsAtividades gestaoLeadsAtividades = db.GestaoLeadsAtividadesSet.Find(id);
            if (gestaoLeadsAtividades == null)
            {
                return HttpNotFound();
            }
            return View(gestaoLeadsAtividades);
        }

        // POST: GestaoLeadsAtividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestaoLeadsAtividades gestaoLeadsAtividades = db.GestaoLeadsAtividadesSet.Find(id);
            db.GestaoLeadsAtividadesSet.Remove(gestaoLeadsAtividades);
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
