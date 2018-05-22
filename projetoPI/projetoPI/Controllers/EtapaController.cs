using projetoPI.Models;
using projetoPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetoPI.Controllers
{
    public class EtapaController : Controller
    {
        EtapaRepository etapaRepository = new EtapaRepository();
        ProcessoRepository processoRepository = new ProcessoRepository();
        // GET: Etapa
        public ActionResult List(int id)
        {
            var pro = processoRepository.GetById(id);
            //SelectListItem[] items3 = new SelectListItem[]
            //    {
            //        new SelectListItem {Text = pro.descricao, Value = pro.id.ToString()}
            //    };

            //ViewData["id_processo"] = items3;
            //var abc = ViewData["id_processo"];
            ViewBag.Id_Processo = id;

            var lista = etapaRepository.GetByIdProcesso(id);
            return View(lista);
        }

        public ActionResult Create(int id_processo)
        {
            var pro = processoRepository.GetById(id_processo);
            SelectListItem[] items3 = new SelectListItem[]
                {
                    new SelectListItem {Text = pro.descricao, Value = pro.id.ToString()}
                };

            ViewData["id_processo"] = items3;

            var abc = ViewData["id_processo"];
            return View();
        }

        [HttpPost]
        public ActionResult Create(etapa etapa)
        {
            etapaRepository.Salvar(etapa);
            return RedirectToAction("List", new { id = etapa.id_processo });
        }

        public ActionResult Edit(int id)
        {
            var et = etapaRepository.GetById(id);
            var pro = processoRepository.GetById(et.id_processo);
            SelectListItem[] items3 = new SelectListItem[]
                {
                    new SelectListItem {Text = pro.descricao, Value = pro.id.ToString()}
                };

            ViewData["id_processo"] = items3;
            return View(et);
        }

        [HttpPost]
        public ActionResult Edit(etapa etapa)
        {
            etapaRepository.Salvar(etapa);
            return RedirectToAction("List", new { id = etapa.id_processo });
        }


        public ActionResult Delete(int id)
        {
            var pro = processoRepository.GetById(etapaRepository.GetById(id).id_processo);
            etapaRepository.Excluir(id);
            return RedirectToAction("List", new { id = pro.id });
        }

    }
}