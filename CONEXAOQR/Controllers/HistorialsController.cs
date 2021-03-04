using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;
using CONEXAOQR.Models;

namespace CONEXAOQR.Controllers
{
    public class HistorialsController : Controller
    {
        private ModelContainer db = new ModelContainer();
        public static DateTime ConvertDate(string dt)
        {
            DateTime result;
            string[] temp = dt.Split('/');
            int dia = int.Parse(temp[0]);
            int mes = int.Parse(temp[1]);
            if (temp[2].Contains(':'))
            {
                string[] aux = temp[2].Split(' ');
                int ano = int.Parse(aux[0]);
                string[] aux1 = aux[1].Split(':');
                int hora = int.Parse(aux1[0]);
                int min = int.Parse(aux1[1]);
                result = new DateTime(ano, mes, dia, hora, min, 0);
            }
            else
            {
                int ano = int.Parse(temp[2]);
                result = new DateTime(ano, mes, dia);
            }



            return result;

        }
        [HttpPost]
        public JsonResult GetUsuarios(string Prefix)
        {  //Note : you can bind same list from database  
            var usuarios = db.Historial.Where(a => a.Usuario.Contains(Prefix)).ToList();
            List<Autocomplete> ObjList = new List<Autocomplete>();
            for (int i = 0; i < usuarios.Count; i++)
            {


                bool f = false;
                for (int j = 0; j < ObjList.Count; j++)
                {
                    if (usuarios[i].Usuario.ToLower() == ObjList[j].Name.ToLower())
                    {
                        f = true;
                        break;
                    }
                }
                if (!f)
                {
                    Autocomplete temp = new Autocomplete();
                    temp.Id = usuarios[i].Id;
                    temp.Name = usuarios[i].Usuario;
                    ObjList.Add(temp);
                }

            }


            //Searching records from list using LINQ query  

            return Json(ObjList, JsonRequestBehavior.AllowGet);

        }
        // GET: Historials
        
        public ActionResult Index(int? page)
        {
            var resutl = db.Historial.OrderBy(l => l.FechaHora).ToList();
            ViewBag.CantRegistros = resutl.Count;
            ViewBag.CurrentSort = null;
            ViewBag.NameSortParm = "Name";
            ViewBag.DateSortParm = "date_desc";
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(resutl.ToPagedList(pageNumber, pageSize));

        }
        
        [HttpPost]
        public ActionResult Index(string columUsuario, string nameReport, string formato, string columFechayHora, string columTipoDeAccion, string columAccion, string d, string accion, string currentFilteraccion, string entrega, string currentFilteren, string sortOrder, string currentFilter, string searchString, int? page, string currentFilterpage, string cantpage, string currentFiltercantpage)
        {



            if (d == "d")
            {
                return RedirectToAction("DescargarHistorial", "Reportes", new { nameReport, formato, columUsuario, columFechayHora, columTipoDeAccion, columAccion, currentFilteraccion, currentFilter, currentFilteren, sortOrder });
            }


            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";

            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            var historial = db.Historial.OrderBy(l => l.FechaHora).ToList();



            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (entrega != null)
            {
                page = 1;
            }
            else
            {
                entrega = currentFilteren;

            }
            if (accion != null)
            {
                page = 1;
            }
            else
            {
                accion = currentFilteraccion;
            }
            if (!String.IsNullOrEmpty(cantpage))
            {
                ViewBag.CurrentFiltercantpage = cantpage;
            }
            if (!String.IsNullOrEmpty(currentFiltercantpage) && String.IsNullOrEmpty(cantpage))
            {
                ViewBag.CurrentFiltercantpage = currentFiltercantpage;
            }

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentFilteren = entrega;
            ViewBag.CurrentFilteraccion = accion;
            var resutl = from s in historial
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                resutl = resutl.Where(s => s.Usuario.ToLower().Contains(searchString.ToLower()));
            }
            if (!String.IsNullOrEmpty(accion))
            {
                resutl = resutl.Where(c => c.TipoAccion == accion);
            }

            if (!String.IsNullOrEmpty(entrega))
            {
                DateTime dt = ConvertDate(entrega);
                DateTime dtt = dt.AddDays(1);
                resutl = resutl.Where(c => c.FechaHora >= dt && c.FechaHora < dtt);

            }
            switch (sortOrder)
            {
                case "name_desc":
                    resutl = resutl.OrderByDescending(s => s.Usuario);
                    break;
                case "Name":
                    resutl = resutl.OrderBy(s => s.Usuario);
                    break;
                case "date_desc":
                    resutl = resutl.OrderByDescending(s => s.FechaHora);
                    break;
                default:
                    resutl = resutl.OrderBy(s => s.FechaHora);
                    break;

            }
            if (page == null && !String.IsNullOrEmpty(currentFilterpage))
            {
                page = int.Parse(currentFilterpage);
            }
            ViewBag.CurrentFilterpage = page;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if (!String.IsNullOrEmpty(cantpage))
            {
                pageSize = int.Parse(cantpage);
            }
            if (!String.IsNullOrEmpty(currentFiltercantpage) && String.IsNullOrEmpty(cantpage))
            {
                pageSize = int.Parse(currentFiltercantpage);
            }

            var historials = resutl as IList<Historial> ?? resutl.ToList();
            ViewBag.CantRegistros = historials.ToList().Count;
            if (Request.IsAjaxRequest())
            {

                return PartialView("HistorialPartial", historials.ToPagedList(pageNumber, pageSize));

            }
            return View(historials.ToPagedList(pageNumber, pageSize));
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
