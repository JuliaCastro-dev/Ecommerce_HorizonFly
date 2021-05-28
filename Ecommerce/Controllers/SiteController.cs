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
        public ActionResult Login(Usuario user, Funcionario func)
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
                Session["tipo"] = user.tipo.ToString();


                // USUARIO TIPO 1 = GERENTE
                // USUARIO TIPO 2 = FUNCIONARIO
                // USUARIO TIPO 3 = CLIENTE
                // USUARIO TIPO 4 = CLIENTE/FUNCIONARIO



                //if (AcoesFuncionario.VerificaFuncionario == 1)
                //{


                if (user.tipo == "2")
                {
                    Session["UsuarioLogado"] = user.cpf.ToString();
                    Session["senhaLogado"] = user.senha.ToString();
                    Session["cpf"] = user.cpf.ToString();
                    Session["senha"] = user.senha.ToString();
                    Session["nome"] = user.nome.ToString();
                    Session["img"] = user.img.ToString();
                    Session["tipoLogado2"] = user.tipo.ToString();//=2

                    return RedirectToAction("Dashboard", "Sistema");
                }
                else if (user.tipo == "1")
                {
                    Session["UsuarioLogado"] = user.cpf.ToString();
                    Session["senhaLogado"] = user.senha.ToString();
                    Session["cpf"] = user.cpf.ToString();
                    Session["senha"] = user.senha.ToString();
                    Session["nome"] = user.nome.ToString();
                    Session["img"] = user.img.ToString();
                    Session["tipoLogado1"] = user.tipo.ToString();//=1



                    return RedirectToAction("Dashboard", "Sistema");
                }
                else if (user.tipo == "4"/* && AcoesCliente.VerificaCliente == 1*/)
                {
                    Session["UsuarioLogado"] = user.cpf.ToString();
                    Session["senhaLogado"] = user.senha.ToString();
                    Session["cpf"] = user.cpf.ToString();
                    Session["senha"] = user.senha.ToString();
                    Session["nome"] = user.nome.ToString();
                    Session["img"] = user.img.ToString();
                    Session["tipoLogado4"] = user.tipo.ToString();//=4

                    return RedirectToAction("Contas", "Sistema");
                }
                else if (user.tipo == "3")
                {
                    Session["UsuarioLogado"] = user.cpf.ToString();
                    Session["senhaLogado"] = user.senha.ToString();
                    Session["cpf"] = user.cpf.ToString();
                    Session["senha"] = user.senha.ToString();
                    Session["nome"] = user.nome.ToString();
                    Session["img"] = user.img.ToString();
                    Session["tipoLogado3"] = user.tipo.ToString(); //=3;

                    return RedirectToAction("PerfilCliente", "Site");
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

        /* PERFIL CLIENTE */

        public ActionResult PerfilCliente()
        {
            ViewBag.nome = Session["nome"];
            ViewBag.img = Session["img"];
            ViewBag.email = Session["email"];
            ViewBag.tel = Session["tel"];
            ViewBag.cpf = Session["cpf"];
            ViewBag.rg = Session["rg"];
            ViewBag.senha = Session["senha"];

            return View();
        }


        public ActionResult CadastroCliente()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCliente(Cliente cliente, HttpPostedFileBase file)
        {

            //acF.VerificaUsuario(cliente);


            if (AcoesFuncionario.Verifica == 1)// se houver um funcionário com o mesmo cpf, ele será cadastrado como ClienteFuncionário
            {



                if (file != null && file.ContentLength > 0)
                {
                    string arquivo = Path.GetFileName(file.FileName);
                    string file2 = "/ImagensCliente/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/ImagensCliente"), arquivo);
                    file.SaveAs(_path);
                    cliente.img = file2;
                    acC.inserirClienteFuncionario(cliente);

                    return RedirectToAction("Login", "Site");
                }
                else
                {
                    acC.inserirClienteFuncionario(cliente);

                    return RedirectToAction("Login", "Site");
                }


            }
            else
            {
                if (file != null && file.ContentLength > 0)
                {
                    string arquivo = Path.GetFileName(file.FileName);
                    string file2 = "/ImagensCliente/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/ImagensCliente"), arquivo);
                    file.SaveAs(_path);
                    cliente.img = file2;
                    acC.inserirCliente(cliente);
                    return RedirectToAction("Login", "Site");
                }
                else
                {
                    acC.inserirCliente(cliente);
                    return RedirectToAction("Login", "Site");
                }




            }

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



        public ActionResult Sobre()
        {
            return View();
        }

    }
}