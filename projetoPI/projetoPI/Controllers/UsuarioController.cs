using projetoPI.Models;
using projetoPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoPI.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioRepository repository = new UsuarioRepository();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(String login, String senha)
        {
            try
            {
                List<usuario> list = repository.GetByName(login);
                usuario us = null;
                if (list.Count > 0)
                    us = list.First();
                if (us != null)
                {
                    if (senha == us.senha)
                        Session["logado"] = us;
                    switch (us.tipo)
                    {
                        case "TI":
                            Response.Redirect("~/TI/Index");
                            break;
                        case "SOCIO":
                            Response.Redirect("~/Socio/Index");
                            break;
                        case "COLABORADOR":
                            Response.Redirect("~/Colaborador/Index");
                            break;
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        public ActionResult Sair()
        {
            Session["logado"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}