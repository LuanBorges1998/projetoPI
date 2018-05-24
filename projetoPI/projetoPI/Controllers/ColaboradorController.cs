using projetoPI.Models;
using projetoPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoPI.Controllers
{
    public class ColaboradorController : Controller
    {
        ProcessoRepository processoRepository = new ProcessoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        ContrarioRepository contrarioRepository = new ContrarioRepository();
        ParceiroRepository parceiroRepository = new ParceiroRepository();
        // GET: Colaborador
        public ActionResult Index()
        {
            var q = processoRepository.GetAll();
            var y = clienteRepository.GetAll();
            var z = contrarioRepository.GetAll();
            var w = parceiroRepository.GetAll();
            ViewBag.Cli = y;
            ViewBag.Con = z;
            ViewBag.Par = w;
            return View(q);
        }

        public ActionResult Create()
        {
            //List<cliente> clientes = clienteRepository.GetAll();
            //SelectListItem[] items;
            //if (clientes.Count > 0)
            //    items = new SelectListItem[clientes.Count];
            //else
            //    items = new SelectListItem[1];
            //int ct = 0;
            //items[ct] = new SelectListItem { Text = "", Value = "" };
            //foreach (cliente client in clientes)
            //{
            //    ct++;
            //    items[ct] = new SelectListItem { Text = client.nome, Value = client.id.ToString() };
            //}
            //ViewData["id_cliente"] = items;

            //List<contrario> contrarios = contrarioRepository.GetAll();
            //SelectListItem[] items2;
            //if (contrarios.Count > 0)
            //    items2 = new SelectListItem[contrarios.Count];
            //else
            //    items2 = new SelectListItem[1];
            //int ct2 = 0;
            //items2[ct2] = new SelectListItem { Text = "", Value = "" };
            //foreach (contrario cont in contrarios)
            //{
            //    ct2++;
            //    items[ct2] = new SelectListItem { Text = cont.nome, Value = cont.id.ToString() };
            //}
            //ViewData["id_contrario"] = items2;

            //SelectListItem[] items3 = new SelectListItem[]
            //    {
            //        new SelectListItem {Text = ((usuario)Session["logado"]).nome, Value = ((usuario)Session["logado"]).id.ToString()}
            //    };

            //ViewData["id_usuario"] = items3;
            //return View();
            return RedirectToAction("Create", "SocioColaborador");
        }

        [HttpPost]
        public ActionResult Create(processo processo)
        {
            processoRepository.Salvar(processo);
            return View();
        }

        public ActionResult Edit(int id)
        {
            //SelectListItem[] items3 = new SelectListItem[]
            //    {
            //        new SelectListItem {Text = ((usuario)Session["logado"]).nome, Value = ((usuario)Session["logado"]).id.ToString()}
            //    };

            //ViewData["id_usuario"] = items3;
            return RedirectToAction("Edit","SocioColaborador", new { id = id });
        }

        [HttpPost]
        public ActionResult Edit(processo processo)
        {
            processoRepository.Salvar(processo);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            processoRepository.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditCliente(int id)
        {
            return RedirectToAction("EditCliente", "SocioColaborador", new { id = id });
        }

        public ActionResult DeleteCliente(int id)
        {
            clienteRepository.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditContrario(int id)
        {
            return RedirectToAction("EditContrario", "SocioColaborador", new { id = id });
        }

        public ActionResult DeleteContrario(int id)
        {
            contrarioRepository.Excluir(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditParceiro(int id)
        {
            return RedirectToAction("EditParceiro", "SocioColaborador", new { id = id });
        }

        public ActionResult DeleteParceiro(int id)
        {
            parceiroRepository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}