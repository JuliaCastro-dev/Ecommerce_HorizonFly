using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Ecommerce.Controllers
{
    public class SistemaController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult DashboardFuncionario()
        {
            return View();
        }
        public ActionResult DashboardGerente()
        {
            return View();
        }
        public ActionResult DashboardCliente()
        {
            return View();
        }




    }
}