using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using UI.Models;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        private AdminViewModel mymodel;
        private VraagManager _vraagManager;

        public AdminController()
        {
            _vraagManager = new VraagManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestVragen()
        {
            return View(_vraagManager.GetAllTestVragen());
        }
    }
}