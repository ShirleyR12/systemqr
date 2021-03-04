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
    public class PiramideSucessoesController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: PiramideSucessoes
        public ActionResult Index()
        {
            var piramideSucessoSet = db.PiramideSucessoSet.Include(p => p.Empresa1).Include(p => p.EmpresaSet);
            return View(piramideSucessoSet.ToList());
        }

        // GET: PiramideSucessoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PiramideSucesso piramideSucesso = db.PiramideSucessoSet.Find(id);
            if (piramideSucesso == null)
            {
                return HttpNotFound();
            }
            return View(piramideSucesso);
        }

        // GET: PiramideSucessoes/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaId1 = new SelectList(db.EmpresaSet, "Id", "nome");
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome");
            return View();
        }

        // POST: PiramideSucessoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,meta,ir,obj1,obj2,obj3,obj4,obj5,atitude1_obj1,atitude2_obj1,atitude3_obj1,atitude4_obj1,atitude5_obj1,atitude1_obj2,atitude2_obj2,atitude3_obj2,atitude4_obj2,atitude5_obj2,atitude1_obj3,atitude2_obj3,atitude3_obj3,atitude4_obj3,atitude5_obj3,atitude1_obj4,atitude2_obj4,atitude3_obj4,atitude4_obj4,atitude5_obj4,atitude1_obj5,atitude2_obj5,atitude3_obj5,atitude4_obj5,atitude5_obj5,dtCriacao,dtUltimoUpdate,ativo,metaBatida,observacao,codValidado,codUsuarioValidou,codUsuarioCriou,EmpresaId1,EmpresaId")] PiramideSucesso piramideSucesso)
        {
            if (ModelState.IsValid)
            {
                db.PiramideSucessoSet.Add(piramideSucesso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId1 = new SelectList(db.EmpresaSet, "Id", "nome", piramideSucesso.EmpresaId1);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", piramideSucesso.EmpresaId);
            return View(piramideSucesso);
        }

        // GET: PiramideSucessoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PiramideSucesso piramideSucesso = db.PiramideSucessoSet.Find(id);
            if (piramideSucesso == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId1 = new SelectList(db.EmpresaSet, "Id", "nome", piramideSucesso.EmpresaId1);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", piramideSucesso.EmpresaId);
            return View(piramideSucesso);
        }

        // POST: PiramideSucessoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,meta,ir,obj1,obj2,obj3,obj4,obj5,atitude1_obj1,atitude2_obj1,atitude3_obj1,atitude4_obj1,atitude5_obj1,atitude1_obj2,atitude2_obj2,atitude3_obj2,atitude4_obj2,atitude5_obj2,atitude1_obj3,atitude2_obj3,atitude3_obj3,atitude4_obj3,atitude5_obj3,atitude1_obj4,atitude2_obj4,atitude3_obj4,atitude4_obj4,atitude5_obj4,atitude1_obj5,atitude2_obj5,atitude3_obj5,atitude4_obj5,atitude5_obj5,dtCriacao,dtUltimoUpdate,ativo,metaBatida,observacao,codValidado,codUsuarioValidou,codUsuarioCriou,EmpresaId1,EmpresaId")] PiramideSucesso piramideSucesso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(piramideSucesso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId1 = new SelectList(db.EmpresaSet, "Id", "nome", piramideSucesso.EmpresaId1);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", piramideSucesso.EmpresaId);
            return View(piramideSucesso);
        }

        // GET: PiramideSucessoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PiramideSucesso piramideSucesso = db.PiramideSucessoSet.Find(id);
            if (piramideSucesso == null)
            {
                return HttpNotFound();
            }
            return View(piramideSucesso);
        }

        // POST: PiramideSucessoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PiramideSucesso piramideSucesso = db.PiramideSucessoSet.Find(id);
            db.PiramideSucessoSet.Remove(piramideSucesso);
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
