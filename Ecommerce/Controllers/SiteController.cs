using Ecommerce.Acoes;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Ecommerce.Controllers
{
    public class SiteController : Controller
    {
        AcoesCliente acC = new AcoesCliente();
        AcoesLogin acL = new AcoesLogin();
        AcoesFuncionario acF = new AcoesFuncionario();


        // GET: Site
        public ActionResult Index()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Pacote pacote)
        {


            return View();

        }


        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario user)
        {
            acL.TestarUsuario(user);


            if (user.cpf != null && user.senha != null)
            {

                FormsAuthentication.SetAuthCookie(user.cpf, false);
                Session["UsuarioLogado"] = user.cpf.ToString();
                Session["senhaLogado"] = user.senha.ToString();
                Session["cpf"] = user.cpf.ToString();
                Session["senha"] = user.senha.ToString();
                Session["nome"] = user.nome.ToString();


                Session["img"] = user.img.ToString();


                // USUARIO TIPO 1 = GERENTE
                // USUARIO TIPO 2 = FUNCIONARIO
                // USUARIO TIPO 3 = CLIENTE
                // USUARIO TIPO 4 = CLIENTE/FUNCIONARIO

                if (user.tipo == "4")
                {
                    Session["tipoLogado4"] = user.tipo.ToString();//=4

                    return RedirectToAction("Contas", "Sistema");
                }
                else if (user.tipo == "3")
                {
                    Session["tipoLogado3"] = user.tipo.ToString(); //=3;
                    Session["rg"] = user.rg.ToString();
                    Session["tel"] = user.telefone.ToString();
                    Session["email"] = user.ToString();
                    return RedirectToAction("Index", "Site");
                }
                else if (user.tipo == "2")
                {
                    Session["tipoLogado2"] = user.tipo.ToString();//=2

                    return RedirectToAction("Dashboard", "Sistema");
                }
                else if (user.tipo == "1")
                {
                    Session["tipoLogado1"] = user.tipo.ToString();//=1
                  


                    return RedirectToAction("Dashboard", "Sistema");
                }

            }
            else
            {
                ViewBag.usuarioNE = "Usuário não encontrado";
                return View();
            }

            return View();

        }


        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            Session["tipoLogado3"] = null;
            Session["rg"] = null;
            Session["tel"] = null;
            Session["email"] = null;
            Session["cpf"] = null;
            Session["senha"] = null;
            Session["nome"] = null;
            Session["img"] = null;
            return RedirectToAction("Index", "Site");
        }

        public ActionResult CadastroCliente()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCliente(Cliente cliente, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensCliente/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensCliente"), arquivo);
                file.SaveAs(_path);
                cliente.img = file2;

                acF.VerificaUsuario(cliente);


                if (cliente.CPF != null && cliente.senha != null)// se houver um funcionário com o mesmo cpf, ele será cadastrado como ClienteFuncionário
                {
                    acC.inserirClienteFuncionario(cliente);

                    return RedirectToAction("Login", "Site");
                }
                else
                {
                    acC.inserirCliente(cliente);
                    return RedirectToAction("Login", "Site");
                }
                    
             

            }
            return View();
        }
        public ActionResult AlterarSenhaEscolha()
        {

            return View();
        }

        public ActionResult AlterarSenhaFuncionario(Funcionario func)
        {
            acL.AlterarSenhaFuncionario(func);
            return View();
        }


        public ActionResult AlterarSenhaCliente(Cliente cli)
        {
            acL.AlterarSenhaCliente(cli);
            return View();
        }

       
        public ActionResult DashboardCliente()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

    }
}