using projetoPI.Models;
using projetoPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoPI.Controllers
{
    public class TIController : Controller
    {
        UsuarioRepository repository = new UsuarioRepository();
        // GET: TI
        public ActionResult Index(String Pesquisa = "")
        {
            SelectListItem[] types = new SelectListItem[]
            {
                new SelectListItem{ Text="TI", Value ="TI"},
                new SelectListItem{ Text="SOCIO", Value="SOCIO"},
                new SelectListItem{ Text="COLABORADOR", Value="COLABORADOR"}
            };
            ViewData["tipos"] = types;

            List<usuario> socios = repository.GetSocio();
            SelectListItem[] items = new SelectListItem[socios.Count+1];
            int ct = 0;
            items[ct] = new SelectListItem { Text = "", Value = "" };
            foreach (usuario user in socios)
            {
                ct++;
                items[ct] = new SelectListItem { Text = user.nome, Value= user.id.ToString()};
            }

            ViewData["id_socio"] = items;

            var q = repository.GetAll();

            if (!String.IsNullOrEmpty(Pesquisa))
                q = q.Where(c => c.nome.Contains(Pesquisa)).ToList();
            q = q.OrderBy(c => c.nome).ToList();

            if (Request.IsAjaxRequest())
                return PartialView("_Usuarios", q);

            return View(q);
        }

        public ActionResult Listar()
        {
            List<usuario> lista = new List<usuario>();
            return View(lista);
        }

        public ActionResult Edit(int id)
        {
            usuario user = repository.GetById(id);
            if (user != null)
                return View(user);
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(usuario user)
        {
            repository.Salvar(user);
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            repository.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(String no, String lo, String se, String tipos, String id_socio)
        {
            usuario novoUsuario = new usuario();
            novoUsuario.nome = no;
            novoUsuario.login = lo;
            novoUsuario.senha = se;
            novoUsuario.tipo = tipos;
            //novoUsuario.id_socio = 0;
            if(!String.IsNullOrEmpty(id_socio))
                novoUsuario.id_socio = int.Parse(id_socio);
            
            repository.Salvar(novoUsuario);
            return RedirectToAction("Index");
        }
    }
}