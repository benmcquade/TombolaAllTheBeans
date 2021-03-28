using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TombolaAllTheBeans.Models;
using TombolaAllTheBeans.Repositories;

namespace TombolaAllTheBeans.Controllers
{
    public class HomeController : Controller
    {
        BeansRepository _beansRepository = new BeansRepository();

        public ActionResult AllTheBeans()
        {
            var today = DateTime.Now.Date;
            var bean = this._beansRepository.GetTodaysBean(today);

            return View(bean);
        }

        public ActionResult Admin()
        {
            var beans = this._beansRepository.GetAllBeans();

            return View(beans);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(Bean bean)
        {
            this._beansRepository.CreateBean(bean);
            return RedirectToAction("Admin");
        }

        public ActionResult Edit(Guid id)
        {
            var bean = this._beansRepository.GetBean(id);
            return View(bean);
        }

        [HttpPost]
        public ActionResult Edit(Bean bean)
        {
            this._beansRepository.UpdateBean(bean);
            return RedirectToAction("Admin");
        }
    }
}