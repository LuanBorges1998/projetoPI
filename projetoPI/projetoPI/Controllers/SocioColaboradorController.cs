using projetoPI.Models;
using projetoPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoPI.Controllers
{
    public class SocioColaboradorController : Controller
    {
        ProcessoRepository processoRepository = new ProcessoRepository();
        ClienteRepository clienteRepository = new ClienteRepository();
        ContrarioRepository contrarioRepository = new ContrarioRepository();
        // GET: SocioColaborador
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            List<cliente> clientes = clienteRepository.GetAll();
            SelectListItem[] items;
            if (clientes.Count > 0)
                items = new SelectListItem[clientes.Count + 1];
            else
                items = new SelectListItem[1];
            int ct = 0;
            items[ct] = new SelectListItem { Text = "", Value = "" };
            foreach (cliente client in clientes)
            {
                ct++;
                items[ct] = new SelectListItem { Text = client.nome, Value = client.id.ToString() };
            }
            ViewData["id_cliente"] = items;

            List<contrario> contrarios = contrarioRepository.GetAll();
            SelectListItem[] items2;
            if (contrarios.Count > 0)
                items2 = new SelectListItem[contrarios.Count + 1];
            else
                items2 = new SelectListItem[1];
            int ct2 = 0;
            items2[ct2] = new SelectListItem { Text = "", Value = "" };
            foreach (contrario cont in contrarios)
            {
                ct2++;
                items2[ct2] = new SelectListItem { Text = cont.nome, Value = cont.id.ToString() };
            }
            ViewData["id_contrario"] = items2;

            SelectListItem[] items3 = new SelectListItem[]
                {
                    new SelectListItem {Text = ((usuario)Session["logado"]).nome, Value = ((usuario)Session["logado"]).id.ToString()}
                };

            ViewData["id_usuario"] = items3;

            return View();
        }

        [HttpPost]
        public ActionResult Create(processo processo)
        {
            processoRepository.Salvar(processo);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }

        public ActionResult Edit(int id)
        {
            processo pro = processoRepository.GetById(id);

            List<cliente> clientes = clienteRepository.GetAll();
            SelectListItem[] items;
            int ct = 0;

            if (clientes.Count > 0)
                items = new SelectListItem[clientes.Count + 1];
            else
                items = new SelectListItem[1];

            if (pro.cliente != null)
            {
                items[ct] = new SelectListItem { Text = pro.cliente.nome, Value = pro.cliente.id.ToString() };
                ct++;
            }

            foreach (cliente client in clientes)
            {
                if (pro.cliente == client)
                    continue;
                items[ct] = new SelectListItem { Text = client.nome, Value = client.id.ToString() };
                ct++;
            }

            items[ct] = new SelectListItem { Text = "", Value = "" };
            ViewData["id_cliente"] = items;






            List<contrario> contrarios = contrarioRepository.GetAll();


            SelectListItem[] items2;

            int ct2 = 0;

            if (contrarios.Count > 0)
                items2 = new SelectListItem[contrarios.Count + 1];
            else
                items2 = new SelectListItem[1];

            if (pro.contrario != null)
            {
                items2[ct2] = new SelectListItem { Text = pro.contrario.nome, Value = pro.cliente.id.ToString() };
                ct2++;
            }

            foreach (contrario  contrario in contrarios)
            {
                if (pro.contrario == contrario)
                    continue;
                items2[ct2] = new SelectListItem { Text = contrario.nome, Value = contrario.id.ToString() };
                ct2++;
            }

            items2[ct2] = new SelectListItem { Text = "", Value = "" };

            ViewData["id_contrario"] = items2;






            SelectListItem[] items3 = new SelectListItem[]
                {
                    new SelectListItem {Text = ((usuario)Session["logado"]).nome, Value = ((usuario)Session["logado"]).id.ToString()}
                };

            ViewData["id_usuario"] = items3;
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(processo processo)
        {
            processoRepository.Salvar(processo);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }

        public ActionResult Delete(int id)
        {
            processoRepository.Excluir(id);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }

        public ActionResult AdicionaCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaCliente(cliente cliente)
        {
            clienteRepository.Salvar(cliente);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }

        public ActionResult EditCliente(int id)
        {
            return View(clienteRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult EditCliente(cliente cliente)
        {
            clienteRepository.Salvar(cliente);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }

        public ActionResult AdicionaContrario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdicionaContrario(contrario contrario)
        {
            contrarioRepository.Salvar(contrario);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }

        public ActionResult EditContrario(int id)
        {
            contrario con = contrarioRepository.GetById(id);
            return View(con);
        }

        [HttpPost]
        public ActionResult EditContrario(contrario contrario)
        {
            contrarioRepository.Salvar(contrario);
            usuario logado = (usuario)Session["logado"];
            if (logado.tipo.Equals("COLABORADOR"))
                return RedirectToAction("Index", "COLABORADOR");
            else
                return RedirectToAction("Index", "SOCIO");
        }
    }
}