using CONEXAOQR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CONEXAOQR.Controllers
{
    public class HomeController : Controller
    {
        private ModelContainer db = new ModelContainer();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult teste()
        {
            List<Grafico> list = new List<Grafico>();
            var totalL = db.GestaoLeadsSet.Where(l => l.etapaLEAD == true && l.EmpresaId == 1).Count();
            var totalA = db.GestaoLeadsSet.Where(l => l.etapaATENDIMENTO == true && l.EmpresaId == 1).Count();
            var totalG = db.GestaoLeadsSet.Where(l => l.etapaAGENDAMENTO == true && l.EmpresaId == 1).Count();
            var totalV = db.GestaoLeadsSet.Where(l => l.etapaVISITA == true && l.EmpresaId == 1).Count();
            var totalP = db.GestaoLeadsSet.Where(l => l.etapaPROPOSTA == true && l.EmpresaId == 1).Count();
            var totalE = db.GestaoLeadsSet.Where(l => l.etapaVENDA == true && l.EmpresaId == 1).Count();

            var lead = totalL > 0 ? totalL : 1;
            Grafico leady = new Grafico();
            leady.y = lead;
            leady.label = "LEAD";

            var atendimento = totalA > 0 ? totalA : 1;
            Grafico atendimentoy = new Grafico();
            atendimentoy.y = atendimento;
            atendimentoy.label = "ATENDIMENTO";

            var agendamento = totalG > 0 ? totalG : 1;
            Grafico agendamentoy = new Grafico();
            agendamentoy.y = agendamento;
            agendamentoy.label = "AGENDAMENTO";

            var visita = totalV > 0 ? totalV : 1;
            Grafico visitay = new Grafico();
            visitay.y = visita;
            visitay.label = "VISITA";

            var proposta = totalP > 0 ? totalP : 1;
            Grafico propostay = new Grafico();
            propostay.y = proposta;
            propostay.label = "PROPOSTA";

            var venda = totalE > 0 ? totalE: 1;
            Grafico venday = new Grafico();
            venday.y = venda;
            venday.label = "VENDA";


            list.Add(leady);
            list.Add(atendimentoy);
            list.Add(agendamentoy);
            list.Add(visitay);
            list.Add(propostay);
            list.Add(venday);

            return Json(list, JsonRequestBehavior.AllowGet);
       
        }

        public JsonResult grafTempoEntradaLead()
        {
            List<Grafico> lista = new List<Grafico>();
            var dataEntrada = db.GestaoLeadsSet.FirstOrDefault().dtEntrada;
            var dataAtual = DateTime.Now;
            var totalLE = 1;
            var totalAE = 1;
            var totalGE = 1;
            var totalVE = 0;
            var totalPE= 0;
            var totalEE = 0;

            var lead = totalLE > 0 ? totalLE : 1;
            Grafico leady = new Grafico();
            leady.y = lead;
            leady.label = "LEAD";

            var atendimento = totalAE > 0 ? totalAE : 1;
            Grafico atendimentoy = new Grafico();
            atendimentoy.y = atendimento;
            atendimentoy.label = "ATENDIMENTO";

            var agendamento = totalGE > 0 ? totalGE : 1;
            Grafico agendamentoy = new Grafico();
            agendamentoy.y = agendamento;
            agendamentoy.label = "AGENDAMENTO";

            var visita = totalVE > 0 ? totalVE : 1;
            Grafico visitay = new Grafico();
            visitay.y = visita;
            visitay.label = "VISITA";

            var proposta = totalPE > 0 ? totalPE : 1;
            Grafico propostay = new Grafico();
            propostay.y = proposta;
            propostay.label = "PROPOSTA";

            var venda = totalEE > 0 ? totalEE : 1;
            Grafico venday = new Grafico();
            venday.y = venda;
            venday.label = "VENDA";


            lista.Add(leady);
            lista.Add(atendimentoy);
            lista.Add(agendamentoy);
            lista.Add(visitay);
            lista.Add(propostay);
            lista.Add(venday);

            return Json(lista, JsonRequestBehavior.AllowGet);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}