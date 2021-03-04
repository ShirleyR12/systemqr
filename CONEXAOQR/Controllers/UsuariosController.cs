using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CONEXAOQR.Models;
using Microsoft.AspNet.Identity.Owin;

namespace CONEXAOQR.Controllers
{
    public class UsuariosController : Controller
    {
        private ModelContainer db = new ModelContainer();

        // GET: Usuarios
        public ActionResult Index()
        {
           var teste  = Session.SessionID;
            var idUser = Session["userIdSession"];
            var emailUser = Session["emailSession"];
            ViewBag.email = emailUser;
            var usuarioSet = db.UsuarioSet.Include(u => u.Empresa).Include(u => u.Filial);

            //Pega o usuário logado
          //  var userid = new ApplicationUser { UserName = users.Email, Email = users.Email };
            //Pega a confirmação de e-mail
            //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id}, protocol: Request.Url.Scheme);

            return View(usuarioSet.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.UsuarioSet.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            var emailUser = Session["emailSession"];
            ViewBag.email = emailUser;
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome");
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome");
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ativo,tipoPessoa,observacao,EmpresaId,FilialId")] Usuario usuario, HttpPostedFileBase fileInput)
        {
            if (ModelState.IsValid)
            {

                if (fileInput?.FileName != null)
                {
                    if (!fileInput.ContentType.Contains("image"))
                    {
                        ViewBag.ImagenInvalida = "yes";

                    }
                    else
                    {
                        string nomePastaNova = Path.GetFileNameWithoutExtension(fileInput.FileName).Split('_')[0] + "_" + DateTime.Now.Ticks + Path.GetExtension(fileInput.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Imagenes_Autos"), nomePastaNova);
                        fileInput.SaveAs(path);
                        usuario.imagem = nomePastaNova;
                        db.UsuarioSet.Add(usuario);
                        db.SaveChanges();
                        ViewBag.CreateSuccess = "yes";
                    }

                }
                usuario.ativo = true;
                usuario.dtCriacao = DateTime.Now;
                db.UsuarioSet.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", usuario.EmpresaId);
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", usuario.FilialId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.UsuarioSet.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", usuario.EmpresaId);
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", usuario.FilialId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ativo,tipoPessoa,observacao,EmpresaId,FilialId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaId = new SelectList(db.EmpresaSet, "Id", "nome", usuario.EmpresaId);
            ViewBag.FilialId = new SelectList(db.FilialSet, "Id", "nome", usuario.FilialId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.UsuarioSet.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.UsuarioSet.Find(id);
            db.UsuarioSet.Remove(usuario);
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
