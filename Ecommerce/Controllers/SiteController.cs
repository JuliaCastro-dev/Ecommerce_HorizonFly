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
        AcoesCartao acCard = new AcoesCartao();
        AcoesLogin acL = new AcoesLogin();
        AcoesFuncionario acF = new AcoesFuncionario();
        AcoesPacote acP = new AcoesPacote();


        // -------------------- PÁGINA PRINCIPAL -------------------
        public ActionResult Index()
        {
            ModelState.Clear();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Pacote pacote)
        {


            return View(acP.BuscaListaPacote(pacote));
        }
        // ---------------------- SOBRE ---------------------

        public ActionResult Sobre()
        {
            return View();
        }

        // ------------- LOGIN ------------------
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario user)
        {

            acF.VerificaLogin(user);
            if (user.cpf != null && user.senha != null)
            {
                FormsAuthentication.SetAuthCookie(user.cpf, false);



                // USUARIO TIPO 1 = GERENTE
                // USUARIO TIPO 2 = FUNCIONARIO
                // USUARIO TIPO 3 = CLIENTE
                // USUARIO TIPO 4 = CLIENTE/FUNCIONARIO



                if (AcoesFuncionario.VerificaFuncionario == 1)
                {
                    Session["UsuarioLogado"] = user.cpf.ToString();
                    Session["senhaLogado"] = user.senha.ToString();
                    Session["cpf"] = user.cpf.ToString();
                    Session["senha"] = user.senha.ToString();
                    Session["rg"] = user.rg.ToString();
                    Session["email"] = user.email.ToString();
                    Session["tel"] = user.telefone.ToString();
                    Session["nome"] = user.nome.ToString();
                    Session["img"] = user.img.ToString();
                    Session["tipo"] = user.tipo.ToString();

                    if (user.tipo == "2")
                    {

                        Session["tipoLogado2"] = user.tipo.ToString();//=2

                        return RedirectToAction("Dashboard", "Sistema");
                    }
                    else if (user.tipo == "1")
                    {

                        Session["tipoLogado1"] = user.tipo.ToString();//=1

                        return RedirectToAction("Dashboard", "Sistema");
                    }
                    else if (user.tipo == "4"/* && AcoesCliente.VerificaCliente == 1*/)
                    {

                        Session["tipoLogado4"] = user.tipo.ToString();//=4

                        return RedirectToAction("Contas", "Sistema");
                    }
                }
                else
                {
                    acC.VerificaUsuarioLogin(user);
                    if (AcoesCliente.VerificaCliente == 1)
                    {
                        Session["UsuarioLogado"] = user.cpf.ToString();
                        Session["senhaLogado"] = user.senha.ToString();
                        Session["cpf"] = user.cpf.ToString();
                        Session["rg"] = user.rg.ToString();
                        Session["senha"] = user.senha.ToString();
                        Session["email"] = user.email.ToString();
                        Session["tel"] = user.telefone.ToString();
                        Session["nome"] = user.nome.ToString();
                        Session["img"] = user.img.ToString();
                        Session["tipo"] = user.tipo.ToString();
                        if (user.tipo == "3")
                        {

                            Session["tipoLogado3"] = user.tipo.ToString(); //=3;

                            return RedirectToAction("PerfilCliente", "Site");
                        }


                    }
                    else
                    {
                        ViewBag.usuarioNE = "Usuário não encontrado";
                        return View();
                    }
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

        /* ------------------- PERFIL CLIENTE -------------------- */

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

        /* ----------------- CADASTRO CLIENTE ---------------- */
        public ActionResult CadastroCliente()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCliente(Cliente cliente, HttpPostedFileBase file, Usuario user)
        {

            //acF.VerificaUsuario(cliente);
            if (ModelState.IsValid)
            {

                acF.VerificaUsuarioCadastroCliente(user);

                if (user.cpf != null)// se houver um funcionário com o mesmo cpf, ele será cadastrado como ClienteFuncionário
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
            else
            {
                ViewBag.erro = "Preencha Todos Os dados";
                return View();
            }

        }

        // --------------------- CADASTRO CARTÃO CLIENTE ---------------------
        public ActionResult CadastroCartao()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CadastroCartao(Cartao card)
        {
            card.cpf = Session["cpf"].ToString();
            if (ModelState.IsValid)
            {
                acCard.inserirCartao(card);
            }
            else
            {
                ViewBag.erro = "Preencha Todos Os dados";
                return View();
            }

            return View();
        }

        // ------------------ ALTERA SENHA ( FUNCIONÁRIO E CLIENTE ) -----------------------
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(Usuario smodel, Funcionario FUNC)
        {
            if (smodel.cpf != null && smodel.senha != null)
            {
                acL.VerificaSenha(FUNC);
                if (AcoesLogin.VerificaSenhaUsu == 1)
                {


                    try
                    {
                        acL.AlterarSenhaFuncionario(smodel);
                        ViewBag.certo = "Mudança Realizada com Sucesso!";
                    }
                    catch
                    {
                        ViewBag.usuarioNE = "Usuario não encontrado";
                    }

                    return View();
                }
                else // se não ele entende que é um cliente
                {

                    try
                    {
                        acL.AlterarSenhaCliente(smodel);
                        ViewBag.certo = "Mudança Realizada com Sucesso!";
                    }
                    catch
                    {
                        ViewBag.usuarioNE = "Usuario não encontrado";
                    }

                    return View();
                }
            }
            else
            {
                return View();
            }


        }


        // ----------------- CARRINHO ------------------------

        public ActionResult Carrinho( )
        {


            return View();
        }
    }
}