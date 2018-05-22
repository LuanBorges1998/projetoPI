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
        PerfilRepository perfilRepository = new PerfilRepository();
        AdvogadoRepository advogadoRepository = new AdvogadoRepository();
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

            List<advogado> socios = advogadoRepository.GetAllSocios();
            SelectListItem[] items = new SelectListItem[socios.Count + 1];
            int ct = 0;
            items[ct] = new SelectListItem { Text = "", Value = "" };
            foreach (advogado user in socios)
            {
                ct++;
                items[ct] = new SelectListItem { Text = user.usuario.nome, Value = user.id.ToString() };
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

            PerfilRepository perfilRepository = new PerfilRepository();
            var perfis = perfilRepository.GetAll();
            SelectListItem[] types = new SelectListItem[3];
            types[0] = new SelectListItem { Text = user.perfil.tipo, Value = user.perfil.id.ToString() };
            int cont = 1;
            foreach (var per in perfis)
            {
                if (per.id == user.id_perfil)
                    continue;
                types[cont] = new SelectListItem { Text = per.tipo, Value = per.id.ToString() };
                cont++;
            }
            ViewData["tipos"] = types;

            if (user != null)
            {
                AdvogadoRepository advogadoRepository = new AdvogadoRepository();
                List<advogado> socios = advogadoRepository.GetAllSocios();
                SelectListItem[] items = new SelectListItem[socios.Count + 1];
                int ct = 0;
                advogado adv = advogadoRepository.GetByIdUsuario(user.id);
                if (user.id_perfil == 2)
                {
                    var soci = advogadoRepository.GetById(int.Parse(adv.id_socio.ToString()));
                    foreach (advogado soc in socios)
                    {
                        if (soc.id == adv.id_socio)
                        {
                            items[ct] = new SelectListItem { Text = soc.usuario.nome, Value = soc.id.ToString() };
                            ct++;
                        }

                    }
                }
                items[ct] = new SelectListItem { Text = "", Value = "" };
                foreach (advogado user2 in socios)
                {
                    if (user2.id == adv.id_socio)
                    {
                        continue;
                    }
                    ct++;
                    items[ct] = new SelectListItem { Text = user2.usuario.nome, Value = user2.id.ToString() };
                }

                ViewData["id_socio"] = items;

                return View(user);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(usuario user, String tipos,String num, String id_socio)
        {
            //usuario novoUsuario = new usuario();
            //novoUsuario.nome = no;
            //novoUsuario.login = lo;
            //novoUsuario.senha = se;
            //novoUsuario.id_perfil = perfilRepository.GetPerfil(tipos).id;
            user.id_perfil = int.Parse(tipos);
            repository.Salvar(user);
            if (user.id_perfil == 2 || user.id_perfil == 3)
            {
                advogado adv = advogadoRepository.GetByIdUsuario(user.id);
                adv.num_oab = num;
                //novoUsuario.id_socio = 0;
                if (!String.IsNullOrEmpty(id_socio))
                {
                    advogado socio = advogadoRepository.GetById(int.Parse(id_socio));
                    adv.id_socio = socio.id;
                }
                advogadoRepository.Salvar(adv);
            }




            //repository.Salvar(user);
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            repository.Excluir(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(String no, String lo, String se, String tipos, String num, String id_socio)
        {
            usuario novoUsuario = new usuario();
            novoUsuario.nome = no;
            novoUsuario.login = lo;
            novoUsuario.senha = se;
            novoUsuario.id_perfil = perfilRepository.GetPerfil(tipos).id;
            repository.Salvar(novoUsuario);
            if (novoUsuario.id_perfil == 2 || novoUsuario.id_perfil == 3)
            {
                advogado novoAdvogado = new advogado();
                novoAdvogado.id_usuario = novoUsuario.id;
                novoAdvogado.num_oab = num;
                //novoUsuario.id_socio = 0;
                if (!String.IsNullOrEmpty(id_socio))
                {
                    advogado socio = advogadoRepository.GetById(int.Parse(id_socio));
                    novoAdvogado.id_socio = socio.id;
                }
                advogadoRepository.Salvar(novoAdvogado);
            }

            return RedirectToAction("Index");
        }
    }
}