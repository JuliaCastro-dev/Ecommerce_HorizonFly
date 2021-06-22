using Ecommerce.Acoes;
using Ecommerce.Models;
using MySql.Data.MySqlClient;
using PagedList;
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
        AcoesReserva acR = new AcoesReserva();
        AcoesLogin acL = new AcoesLogin();
        AcoesItens acI = new AcoesItens();
        AcoesFuncionario acF = new AcoesFuncionario();
        AcoesPacote acP = new AcoesPacote();

        //-------------- CARREGA CIDADES ---------------------------------------------------
        public void carregaCidades()
        {
            List<SelectListItem> cidade = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Cidade;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cidade.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString(),

                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.cidade = new SelectList(cidade, "Value", "Text");
        }

        //-------------- CARREGA CIDADES PARA ORIGEM ---------------------------------------------------

        public void carregaCidadesOrigem()
        {
            List<SelectListItem> cidadeOrigem = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Cidade;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cidadeOrigem.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString(),

                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.cidadeOrigem = new SelectList(cidadeOrigem, "Value", "Text");
        }
        // -------------------- PÁGINA PRINCIPAL -------------------

        public ActionResult Index(int? pagina)
        {
            carregaCidades();
            carregaCidadesOrigem();
            ModelState.Clear();
            int tamanhoPag = 3;
            int numeroPag = pagina ?? 1;
            ViewBag.oferta = acP.EmOferta().ToPagedList(numeroPag, tamanhoPag);
            return View();
        }

     
        /* RETORNA A BUSCA DE PACOTE */
        public ActionResult BuscaPacotes(Pacote pacote, FormCollection frm)
        {
            pacote.cd_cidDestino = frm["cidade"].ToString();
            pacote.cd_cidOrigem =  frm["cidadeOrigem"].ToString();
            ViewBag.listaPacotes = acP.BuscaListaPacote(pacote);
            return View();
        }

        //------------------- DETALHE PACOTES ---------------------
        public ActionResult DetalhePacote(string id, AcoesPacote pacote)
        {
            return View(pacote.GetDetalhesPacote().Find((smodel => smodel.cd_pacote == id)));
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

        public ActionResult PerfilCliente(Cartao card, Cliente cli, Reserva reser)
        {
            ViewBag.nome = Session["nome"];
            ViewBag.img = Session["img"];
            ViewBag.email = Session["email"];
            ViewBag.tel = Session["tel"];
            ViewBag.cpf = Session["cpf"];
            ViewBag.rg = Session["rg"];
            ViewBag.senha = Session["senha"];

            card.cpf = Session["cpf"].ToString();
            ViewBag.listaCartoes = acCard.GetCartoes(card);
            reser.cpf_cliente = Session["cpf"].ToString();
            ViewBag.listaReservas = acR.GetReservas(reser);
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
        [ValidateAntiForgeryToken]
        public ActionResult CadastroCartao(Cartao card)
        {
            card.cpf = Session["cpf"].ToString();
            string mes = card.mes;
            string ano = card.ano;
            card.validade = ano + "/" + mes + "/01" ;

            if (card.cpf != null && card.num_cartao != null)
            {
                acCard.inserirCartao(card);
                return RedirectToAction("PerfilCliente");
            }
            else
            {
                ViewBag.erro = "Preencha Todos Os dados";
                
            }

            return View();
        }


        //------------------- VIEW MEUS CARTÕES---------------------
        public ActionResult MeusCartoes(string id, AcoesCartao cartao)
        {
            return View(cartao.GetDetalhesCartao().Find((smodel => smodel.rg == id)));
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



        //----------------------- ATUALIZAR FUNCIONARIO --------------------


        public ActionResult AtualizaCliente(string id, Cliente cliente)
        {

            if (id != null)
            {
                Session["rg"] = id;
                cliente.rg = id;
                acC.PegaDados(cliente);

                ViewBag.nome = cliente.nome;
                ViewBag.email = cliente.email;
                ViewBag.tel = cliente.telefone;
                ViewBag.cpf = cliente.CPF;
                ViewBag.rg = cliente.rg;
                ViewBag.tipo = cliente.tipo;

                ViewBag.senha = cliente.senha;
               
                return View();
            }
            else
            {
                return RedirectToAction("PerfilCliente");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizaCliente(Cliente cliente, HttpPostedFileBase file, string id)
        {



            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/ImagensCliente/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/ImagensCliente"), arquivo);
            file.SaveAs(_path);
            cliente.img = file2;
            //func.rg = Session["rg"].ToString();
            cliente.rg = id;


            acC.atualizarCliente(cliente);
            return RedirectToAction("Clientes");
        }


        // ----------------- CARRINHO ------------------------

        public static string codigo;

        public ActionResult AdicionarCarrinho(int id, double pre)
        {
            Reserva carrinho = Session["Carrinho"] != null ? (Reserva)Session["Carrinho"] : new Reserva();
            var pacote = acP.GetConsPac(id);
            codigo = id.ToString();

            Pacote pac = new Pacote();

            if (pacote != null)
            {
                var itemPedido = new Itens();
                itemPedido.cd_itens = Guid.NewGuid();
                itemPedido.cd_pacote = id.ToString();
                itemPedido.nome_pacote = pacote[0].nome_pacote;
                itemPedido.qt = 1;
                itemPedido.vl_unit = pre;

                List<Itens> x = carrinho.ItensPedido.FindAll(l => l.cd_pacote == itemPedido.cd_pacote);

                if (x.Count != 0)
                {
                    carrinho.ItensPedido.FirstOrDefault(p => p.cd_pacote == pacote[0].vl_pacote).qt += 1;
                    itemPedido.vl_parcial = itemPedido.qt * itemPedido.vl_unit;
                    carrinho.vl_total += itemPedido.vl_parcial;
                    carrinho.ItensPedido.FirstOrDefault(p => p.cd_pacote == pacote[0].nome_pacote).vl_parcial = carrinho.ItensPedido.FirstOrDefault(p => p.cd_pacote == pacote[0].nome_pacote).qt * itemPedido.vl_unit;

                }

                else
                {
                    itemPedido.vl_parcial = itemPedido.qt * itemPedido.vl_unit;
                    carrinho.vl_total += itemPedido.vl_parcial;
                    carrinho.ItensPedido.Add(itemPedido);
                }

                /*carrinho.ValorTotal = carrinho.ItensPedido.Select(i => i.Produto).Sum(d => d.Valor);*/

                Session["Carrinho"] = carrinho;
            }

            return RedirectToAction("Carrinho");
        }

        public ActionResult Carrinho()
        {

            Reserva carrinho = Session["Carrinho"] != null ? (Reserva)Session["Carrinho"] : new Reserva();
            return View(carrinho);
        }

        public ActionResult EscolherCartao(Cartao card)
        {

            Reserva carrinho = Session["Carrinho"] != null ? (Reserva)Session["Carrinho"] : new Reserva();
            card.cpf = Session["cpf"].ToString();
            ViewBag.listaCartoes = acCard.GetCartoes(card);
            return View();
        }


        public ActionResult SalvarCarrinho(Reserva x, string card)
        {

            if ((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))

            {
                return RedirectToAction("Login", "Site");
            }
            else
            {
                var carrinho = Session["Carrinho"] != null ? (Reserva)Session["Carrinho"] : new Reserva();

                Reserva md = new Reserva();
                Itens mdV = new Itens();

                md.dt_reserva = DateTime.Now.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
                md.cpf_cliente = Session["cpf"].ToString();
                md.vl_total = carrinho.vl_total;
                md.cd_cartao = carrinho.cd_cartao;

                acR.inserirReserva(md);


                //acV.buscaIdVenda(x);

                for (int i = 0; i < carrinho.ItensPedido.Count; i++)
                {

                    mdV.cd_reserva = x.cd_reserva;
                    mdV.cd_pacote = carrinho.ItensPedido[i].cd_reserva;
                    mdV.qt = carrinho.ItensPedido[i].qt;
                    mdV.vl_parcial = carrinho.ItensPedido[i].vl_parcial;
                    acI.inserirItem(mdV);
                }

                carrinho.vl_total = 0;
                carrinho.ItensPedido.Clear();

                return RedirectToAction("ResumoCompra");
            }
        }



        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (Reserva)Session["Carrinho"] : new Reserva();
            var itemExclusao = carrinho.ItensPedido.FirstOrDefault(i => i.cd_itens == id);

            carrinho.vl_total -= itemExclusao.vl_parcial;

            carrinho.ItensPedido.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

    }
}