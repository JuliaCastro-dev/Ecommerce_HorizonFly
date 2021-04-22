using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecommerce.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Pacote pacote)
        {
            ModelState.Clear();
            return View();
        }
        public ActionResult Login()
        {
            ModelState.Clear();
            return View();
        }
       [HttpPost] 
        public ActionResult Login(Login user)
        {
            ModelState.Clear();
            acl.TestarUsuario(user);

            if (user.usuario != null && user.senha != null)
            {
                FormsAuthentication.SetAuthCookie(user.usuario, false);
                Session["usuarioLogado"] = user.usuario.ToString();
                Session["senhaLogado"] = user.senha.ToString();

                // USUARIO TIPO 1 = FUNCIONARIO lindoo
                // USUARIO TIPO 2 = BARBEIRO top
                // USUARIO TIPO 3 = CLIENTE blu

                if (user.tipo == "1")
                {
                    Session["tipoLogado1"] = user.tipo.ToString(); //=1;

                    return RedirectToAction("DashboardFuncionario", "Sistema");
                }
                else if (user.tipo == "2")
                {
                    Session["tipoLogado2"] = user.tipo.ToString();//=2

                    return RedirectToAction("DashboardGerente", "Sistema");
                }
                else
                {
                    Session["tipoLogado3"] = user.tipo.ToString();//=3

                    return RedirectToAction("DashboardCliente", "Sistema");
                }
            }
            return View();
        }

    }
}