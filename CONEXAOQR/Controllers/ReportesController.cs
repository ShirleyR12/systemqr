using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Web;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using PagedList;
using CONEXAOQR.Models;
using Microsoft.Reporting.WebForms;

namespace CONEXAOQR.Controllers
{
    public class ReportesController : Controller
    {
        // GET: Reportes
        private ModelContainer db = new ModelContainer();
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
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
        public static bool IsBetween(DateTime startDate, DateTime endDate, DateTime dt)
        {

            if (dt.Date >= startDate.Date && dt.Date <= endDate.Date)
            {
                return true;
            }
            return false;

        }
        public static List<DateTime> ListaDateTimes(DateTime startDate, long dias)
        {
            List<DateTime> lista = new List<DateTime>();

            for (int i = 0; i < dias; i++)
            {
                lista.Add(startDate);
                startDate = startDate.AddDays(1);
            }
            lista.Add(startDate);

            return lista;
        }



        public ActionResult DescargarHistorial(string nameReport, string formato, string columUsuario, string columFechayHora, string columTipoDeAccion, string columAccion, string currentFilteraccion, string currentFilter, string currentFilteren, string sortOrder)
        {

            var resutl = from s in db.Historial
                         select s;

            if (!String.IsNullOrEmpty(currentFilter))
            {
                resutl = resutl.Where(s => s.Usuario.ToLower().Contains(currentFilter.ToLower()));
            }
            if (!String.IsNullOrEmpty(currentFilteraccion))
            {
                resutl = resutl.Where(c => c.TipoAccion == currentFilteraccion);
            }


            if (!String.IsNullOrEmpty(currentFilteren))
            {
                DateTime dt = ConvertDate(currentFilteren);
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

            List<Historial> listaHistorial = new List<Historial>();
            listaHistorial = resutl.ToList();
            List<ReporteHistorial> datos = new List<ReporteHistorial>();




            for (int i = 0; i < listaHistorial.Count; i++)
            {
                ReporteHistorial listaReporteHistorial = new ReporteHistorial();
                listaReporteHistorial.Id = listaHistorial[i].Id;
                listaReporteHistorial.Usuario = listaHistorial[i].Usuario;
                listaReporteHistorial.FechayHora = listaHistorial[i].FechaHora;
                listaReporteHistorial.TipoDeAccion = listaHistorial[i].TipoAccion;
                listaReporteHistorial.Accion = listaHistorial[i].Accion;


                if (columUsuario == "on")
                {
                    listaReporteHistorial.OcultarUsuario = 1;
                }
                if (columFechayHora == "on")
                {
                    listaReporteHistorial.OcultarFechayHora = 1;
                }
                if (columTipoDeAccion == "on")
                {
                    listaReporteHistorial.OcultarTipoDeAccion = 1;
                }
                if (columAccion == "on")
                {
                    listaReporteHistorial.OcultarAccion = 1;
                }

                datos.Add(listaReporteHistorial);


            }

            nameReport = nameReport + ".";

            string DirectorioReportesRelativo = "~/";
            string urlArchivo = string.Format("{0}.{1}", "Reporte/ReporteHistorial", "rdlc");

            string FullPathReporte = string.Format("{0}{1}",
                HttpContext.Server.MapPath(DirectorioReportesRelativo),
                urlArchivo);
            ReportViewer Reporte = new ReportViewer();
            Reporte.Reset();
            Reporte.LocalReport.ReportPath = FullPathReporte;
            ReportDataSource DataSource = new ReportDataSource("DSMiReporteDeHistorial", datos);
            Reporte.LocalReport.DataSources.Clear();
            Reporte.LocalReport.DataSources.Add(DataSource);

            Warning[] warnings;
            string[] streamIds;
            string contentType;
            string encoding;
            string extension;

            //Export the RDLC Report to Byte Array.

            byte[] bytes = Reporte.LocalReport.Render(formato, null, out contentType, out encoding, out extension, out streamIds, out warnings);

            //Download the RDLC Report in Word, Excel, PDF and Image formats.
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + nameReport + "." + extension);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
            return View();

        }
    }
}