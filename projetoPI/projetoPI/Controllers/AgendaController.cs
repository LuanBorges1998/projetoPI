using projetoPI.Models;
using projetoPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoPI.Controllers
{
    public class AgendaController : Controller
    {
        AgendamentoRepository repository = new AgendamentoRepository();
        // GET: Agenda
        public ActionResult Index()
        {
            usuario logado = (usuario)Session["logado"];
            List<agendamento> lista = repository.GetDeUmUsuario(logado.id);
            return View(lista);
        }

        public ActionResult Criar()
        {
            SelectListItem[] items = new SelectListItem[]
                {
                    new SelectListItem {Text = ((usuario)Session["logado"]).nome, Value = ((usuario)Session["logado"]).id.ToString()}
                };

            ViewData["id_usuario"] = items;
            return View();
        }

        [HttpPost]
        public ActionResult Criar(agendamento agendamento)
        {
            repository.Salvar(agendamento);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            SelectListItem[] items = new SelectListItem[]
                {
                    new SelectListItem {Text = ((usuario)Session["logado"]).nome, Value = ((usuario)Session["logado"]).id.ToString()}
                };

            ViewData["id_usuario"] = items;
            return View(repository.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(agendamento agendamento)
        {
            repository.Salvar(agendamento);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}