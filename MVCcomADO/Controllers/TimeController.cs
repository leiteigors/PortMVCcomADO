using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCcomADO.Controllers
{
    public class TimeController : Controller
    {
        private Rep.TimeRepositorio _repTime;

        public ActionResult ObterTodos()
        {
            _repTime = new Rep.TimeRepositorio();

            ModelState.Clear();
            return View(_repTime.ObterTimes());
        }

        [HttpGet]
        public ActionResult IncluirTime()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirTime(Models.Time time)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repTime = new Rep.TimeRepositorio();

                    if (_repTime.AdicionarTime(time))
                    {
                        ViewBag.Mensagem = "Time Cadastrado com sucesso!";
                    }
                    return RedirectToAction("ObterTodos");

                }
                return View();
            }
            catch (Exception)
            {
                return View("ObterTodos");
            }
        }
        
        [HttpGet]
        public ActionResult EditarTime(int id)
        {
            _repTime = new Rep.TimeRepositorio();
            return View(_repTime.ObterTimes().Find(t => t.id == id));
        }

        [HttpPost]
        public ActionResult EditarTime(int id, Models.Time time)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repTime = new Rep.TimeRepositorio();
                    _repTime.AtualizarTime(time);

                    return RedirectToAction("ObterTodos");
                }
                catch (Exception)
                {
                    return View();
                }
            }
            return View();
        }


        public ActionResult ExlcuirTime(int id)
        {
            try
            {
                _repTime = new Rep.TimeRepositorio();
                if (_repTime.ExcluirTime(id))
                {
                    ViewBag.Mensagem = "Time excluido";
                }
                return RedirectToAction("ObterTodos");
            }
            catch (Exception e)
            {
                return View(ObterTodos());
            }
        }
        
        [HttpGet]
        public ActionResult ObterPorId(int id)
        {
            try
            {
                _repTime = new Rep.TimeRepositorio();
                

                return View(_repTime.ObterPorId(id));
            }
            catch (Exception e)
            {
                return View(ObterTodos());
            }
        }
    }
}