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
    public class GestaoLeadsController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: GestaoLeads
        public ActionResult Index()
        {
            var gestaoLeadsSet = db.GestaoLeadsSet.Include(g => g.CanalAtracao).Include(g => g.JustContato).Include(g => g.CanalComunicacao).Include(g => g.TipoImoveis).Include(g => g.TipoContato).Include(g => g.Empresa).Include(g => g.Filial).Include(g => g.JustAvanco);
            return View(gestaoLeadsSet.ToList());
        }

        // GET: GestaoLeads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeads gestaoLeads = db.GestaoLeadsSet.Find(id);
            if (gestaoLeads == null)
            {
                return HttpNotFound();
            }
            return View(gestaoLeads);
        }

        // GET: GestaoLeads/Importar
        public ActionResult Importar()
        {

            ViewBag.CanalAtracaoId = new SelectList(db.CanalAtracaoSet, "Id", "nome");
            ViewBag.JustContatoId = new SelectList(db.JustContatoSet, "Id", "nome");
            ViewBag.CanalComunicacaoId = new SelectList(db.CanalComunicacaoSet, "Id", "nome");
            ViewBag.TipoImoveisId = new SelectList(db.TipoImoveisSet, "Id", "nome");
            ViewBag.TipoContatoId = new SelectList(db.TipoContatoSet, "Id", "nome");
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome");
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome");
            ViewBag.JustAvancoId = new SelectList(db.JustAvancoSet, "Id", "nome");
            return View();
        }

        // GET: GestaoLeads/Create
        public ActionResult Create()
        {
            ViewBag.CanalAtracaoId = new SelectList(db.CanalAtracaoSet, "Id", "nome");
            ViewBag.JustContatoId = new SelectList(db.JustContatoSet, "Id", "nome");
            ViewBag.CanalComunicacaoId = new SelectList(db.CanalComunicacaoSet, "Id", "nome");
            ViewBag.TipoImoveisId = new SelectList(db.TipoImoveisSet, "Id", "nome");
            ViewBag.TipoContatoId = new SelectList(db.TipoContatoSet, "Id", "nome");
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome");
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome");
            ViewBag.JustAvancoId = new SelectList(db.JustAvancoSet, "Id", "nome");


            return View();
        }

        // POST: GestaoLeads/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "Id,dtEntrada,nome,qtdContato,dtPrimeiraVisita,tempoEntrada,bandB,bandA,bandN,bandD,etapaLEAD,etapaATENDIMENTO,etapaAGENDAMENTO,etapaVISITA,etapaPROPOSTA,etapaVENDA,observacao,dtCadastro,JustContatoId,CanalAtracaoId,CanalComunicacaoId,valorImovel,TipoContatoId,sexo,cidade,TipoImoveisId,VisitasId,SituacaoId,EmpresaId,FilialId,JustAvancoId,importado")] GestaoLeads gestaoLeads)
        {
            if (ModelState.IsValid)
            {
                gestaoLeads.dtCadastro = DateTime.Now;

             
                gestaoLeads.SituacaoId = 1;
                gestaoLeads.importado = false; 
                //Colocar o usuario vinculado ao corretor cadastrado
                gestaoLeads.CorretorId  = db.CorretorSet.FirstOrDefault().Id;
                gestaoLeads.ativo = "ATIVO";
                gestaoLeads.FilialId = 1;

                db.GestaoLeadsSet.Add(gestaoLeads);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CanalAtracaoId = new SelectList(db.CanalAtracaoSet, "Id", "nome", gestaoLeads.CanalAtracaoId);
            ViewBag.JustContatoId = new SelectList(db.JustContatoSet, "Id", "nome", gestaoLeads.JustContatoId);
            ViewBag.CanalComunicacaoId = new SelectList(db.CanalComunicacaoSet, "Id", "nome", gestaoLeads.CanalComunicacaoId);
            ViewBag.TipoImoveisId = new SelectList(db.TipoImoveisSet, "Id", "nome", gestaoLeads.TipoImoveisId);
            ViewBag.TipoContatoId = new SelectList(db.TipoContatoSet, "Id", "nome", gestaoLeads.TipoContatoId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", gestaoLeads.EmpresaId);
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", gestaoLeads.FilialId);
            ViewBag.JustAvancoId = new SelectList(db.JustAvancoSet, "Id", "nome", gestaoLeads.JustAvancoId);
            return  View();
        }
        public JsonResult FilialCombo(int Id)
        {
            var filial = db.FilialSet.ToList().Where(p => p.EmpresaId == Id);
            ViewBag.GerenteNome = "GerenteNome";
            ViewBag.DiretorNome = "DiretorNome";

            return Json(new SelectList(filial, "Id", "nome"));
        }
        // GET: GestaoLeads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeads gestaoLeads = db.GestaoLeadsSet.Find(id);
            if (gestaoLeads == null)
            {
                return HttpNotFound();
            }
            ViewBag.CanalAtracaoId = new SelectList(db.CanalAtracaoSet, "Id", "nome", gestaoLeads.CanalAtracaoId);
            ViewBag.JustContatoId = new SelectList(db.JustContatoSet, "Id", "nome", gestaoLeads.JustContatoId);
            ViewBag.CanalComunicacaoId = new SelectList(db.CanalComunicacaoSet, "Id", "nome", gestaoLeads.CanalComunicacaoId);
            ViewBag.TipoImoveisId = new SelectList(db.TipoImoveisSet, "Id", "nome", gestaoLeads.TipoImoveisId);
            ViewBag.TipoContatoId = new SelectList(db.TipoContatoSet, "Id", "nome", gestaoLeads.TipoContatoId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", gestaoLeads.EmpresaId);
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", gestaoLeads.FilialId);
            ViewBag.JustAvancoId = new SelectList(db.JustAvancoSet, "Id", "nome", gestaoLeads.JustAvancoId);
            return View(gestaoLeads);
        }

        // POST: GestaoLeads/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dtEntrada,nome,qtdContato,dtPrimeiraVisita,tempoEntrada,bandB,bandA,bandN,bandD,etapaLEAD,etapaATENDIMENTO,etapaAGENDAMENTO,etapaVISITA,etapaPROPOSTA,etapaVENDA,observacao,dtCadastro,JustContatoId,CanalAtracaoId,CanalComunicacaoId,valorImovel,TipoContatoId,sexo,cidade,TipoImoveisId,VisitasId,SituacaoId,EmpresaId,FilialId,JustAvancoId,importado")] GestaoLeads gestaoLeads)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gestaoLeads).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CanalAtracaoId = new SelectList(db.CanalAtracaoSet, "Id", "nome", gestaoLeads.CanalAtracaoId);
            ViewBag.JustContatoId = new SelectList(db.JustContatoSet, "Id", "nome", gestaoLeads.JustContatoId);
            ViewBag.CanalComunicacaoId = new SelectList(db.CanalComunicacaoSet, "Id", "nome", gestaoLeads.CanalComunicacaoId);
            ViewBag.TipoImoveisId = new SelectList(db.TipoImoveisSet, "Id", "nome", gestaoLeads.TipoImoveisId);
            ViewBag.TipoContatoId = new SelectList(db.TipoContatoSet, "Id", "nome", gestaoLeads.TipoContatoId);
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", gestaoLeads.EmpresaId);
            ViewBag.FilialId1 = new SelectList(db.FilialSet, "Id", "nome", gestaoLeads.FilialId);
            ViewBag.JustAvancoId = new SelectList(db.JustAvancoSet, "Id", "nome", gestaoLeads.JustAvancoId);
            return View(gestaoLeads);
        }

        // GET: GestaoLeads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestaoLeads gestaoLeads = db.GestaoLeadsSet.Find(id);
            if (gestaoLeads == null)
            {
                return HttpNotFound();
            }
            return View(gestaoLeads);
        }

        // POST: GestaoLeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestaoLeads gestaoLeads = db.GestaoLeadsSet.Find(id);
            db.GestaoLeadsSet.Remove(gestaoLeads);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Leads()
        {
            return View();
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
