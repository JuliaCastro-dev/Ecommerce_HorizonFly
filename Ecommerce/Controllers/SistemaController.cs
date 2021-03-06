using Ecommerce.Acoes;
using Ecommerce.Models;
using Ecommerce.Models.ViewsModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Ecommerce.Controllers
{

    public class SistemaController : Controller
    {

        conexao con = new conexao();

        AcoesFuncionario acF = new AcoesFuncionario();
        AcoesCliente acC = new AcoesCliente();
        AcoesCartao acCar = new AcoesCartao();
        AcoesHotel acH = new AcoesHotel();
        AcoesPacote acP = new AcoesPacote();
        AcoesReserva acR = new AcoesReserva();
        AcoesSistema acS = new AcoesSistema();
        AcoesTransporte acT = new AcoesTransporte();
        AcoesViagem acV = new AcoesViagem();


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
        //-------------- CARREGA CATEGORIAS---------------------------------------------------
        public void carregaCategoria()
        {
            List<SelectListItem> categoria = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Categoria order by categoria;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    categoria.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.categoria = new SelectList(categoria, "Value", "Text");
        }

        //-------------- CARREGA CATEGORIAS---------------------------------------------------
        public void carregaPacotes()
        {
            List<SelectListItem> pacote = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Pacote order by nome_pacote;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    pacote.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.pacote = new SelectList(pacote, "Value", "Text");
        }
        //-------------- CARREGA TIPO DE TRANSPORTE ---------------------------------------------------

        public void carregaTiposTransporte()
        {
            List<SelectListItem> tipo = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from TipoTransporte order by tipo_transporte;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tipo.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.tipo = new SelectList(tipo, "Value", "Text");
        }
        //-------------- CARREGA HOTEIS ---------------------------------------------------
        public void carregaHoteis()
        {
            List<SelectListItem> hotel = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Hotel order by nome_hotel;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    hotel.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.hotel = new SelectList(hotel, "Value", "Text", "Valor");
        }

        public void carregaHoteisValor()
        {
            List<SelectListItem> hotel = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Hotel order by nome_hotel;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    hotel.Add(new SelectListItem
                    {

                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString()

                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.hotel = new SelectList(hotel, "Value", "Text");
        }

        //-------------- CARREGA VIAGENS --------------------------------------------
        public void carregaViagens()
        {
            List<SelectListItem> Viagem = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Viagem order by destino;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Viagem.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.viagem = new SelectList(Viagem, "Value", "Text");
        }
        //-------------- CARREGA TRANSPORTES-------------------------------------------
        public void carregaTransportes()
        {
            List<SelectListItem> transportes = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Transporte order by nome_transporte;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    transportes.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.transportes = new SelectList(transportes, "Value", "Text");
        }
        // DUPLICAÇÃO DE LISTA PARA DIFERENCIAR ELEMENTOS NO ARQUIVO MASCARAS.JS
        public void carregaTransportesOrigem()
        {
            List<SelectListItem> transportesOrigem = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Transporte order by nome_transporte;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    transportesOrigem.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.transportesOrigem = new SelectList(transportesOrigem, "Value", "Text");
        }

        //-------------- DASHBOARD -----------
        public ActionResult Dashboard()
        {
            ModelState.Clear();
            ViewBag.nome = Session["nome"];
            ViewBag.img = Session["img"];
            ViewBag.qtFuncionários = acS.ListarQuantidadeFuncionarios();
            ViewBag.qtViagens = acS.ListarQuantidadeViagens();
            ViewBag.qtClientes = acS.ListarQuantidadeClientes();
            ViewBag.qtTransportes = acS.ListarQuantidadeTransportes();
            ViewBag.qtPacotes = acS.ListarQuantidadePacotes();
            ViewBag.qtReservas = acS.ListarQuantidadeReservas();
            ViewBag.qtHoteis = acS.ListarQuantidadeHoteis();

            return View();
        }

        //------------------------- VIEW ESCOLHA DE CONTAS CLIENTE E FUNCIONÁRIO -----------------------
        public ActionResult Contas()
        {
            return View();
        }

        //-------------------------- VIEWS CADASTRO ----------------------------------------------------

        //---------------------- CADASTRO FUNCIONÁRIOS -------------------------------------------------
        public ActionResult CadastroFuncionario()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroFuncionario(Funcionario func, HttpPostedFileBase file)
        {
            ModelState.Clear();
            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
                file.SaveAs(_path);
                func.img = file2;
                // -------------------
                acF.inserirFuncionario(func);
                // -------------------
                ViewBag.sucesso = "Funcionário Cadastrado com Sucesso";
                return View();

            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }

        }


        //------------------ CADASTRO TRANSPORTES ----------------------------------------------
        public ActionResult CadastroTransportes()
        {
            carregaTiposTransporte(); // carrega a lista de Tipos de Transporte
            carregaCidades(); // carrega a lista de cidades
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroTransportes(Transporte trans, HttpPostedFileBase file)
        {
            ModelState.Clear();
            carregaTiposTransporte(); // carrega a lista de Tipos de Transporte
            carregaCidades(); // carrega a lista de cidades
            // ----------------------------------------------
            trans.tipo_transporte = Request["tipo"];
            trans.cidade_transporte = Request["cidade"];

            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensTransporte/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensTransporte"), arquivo);
                file.SaveAs(_path);
                trans.img_transporte = file2;
                // -------------------
                acT.inserirTransporte(trans);
                // -------------------
                ViewBag.sucesso = "Transporte Cadastrado com Sucesso";
                return View();

            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }

        }

        //--------------------- CADASTRO VIAGENS ------------------------------------------
        public ActionResult CadastroViagens()
        {
            carregaTiposTransporte(); // carrega a lista de Tipos de Transporte
            carregaTransportes(); // carrega a lista de Transportes para o destino 
            carregaTransportesOrigem(); // carrega a lista de Transportes para a Origem
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroViagens(Viagem viagem, HttpPostedFileBase file)
        {
            ModelState.Clear();
            carregaTiposTransporte(); // carrega a lista de Tipos de Transporte
            carregaTransportes();// carrega a lista de Transportes
            carregaTransportesOrigem(); // carrega a lista de Transportes para a Origem
            // ----------------------------------------------
            viagem.tipo_transporte = Request["tipo"]; // Atribui o Tipo escolhido ao campo tipo_transporte
            viagem.destino = Request["transportes"];  // Atribui o Transporte escolhido ao campo Destino
            viagem.origem = Request["transportesOrigem"];  // Atribui o Tipo escolhido ao campo  Origem


            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensViagem/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensViagem"), arquivo);
                file.SaveAs(_path);
                viagem.img_viagem = file2;
                // ---------------------------------------
                // retira cifrão e ponto do valor 
                string preco = viagem.vl_total;

                preco = String.Format("{0:C}", preco);

                viagem.vl_total = preco;
                //-------------------------------------

                acV.inserirViagem(viagem);

                ViewBag.sucesso = "Viagem Cadastrada com Sucesso";
                return View();

            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }

        }

        //------------------------- CADASTRO DE HOTÉIS ----------------------------------
        public ActionResult CadastroHoteis()
        {

            carregaCidades(); // carrega a lista de cidades
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroHoteis(Hotel hotel, HttpPostedFileBase file, string nmcidade)
        {
            ModelState.Clear();

            carregaCidades(); // carrega a lista de cidades
            hotel.cd_cidade = Request["cidade"];

            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensHoteis/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensHoteis"), arquivo);
                file.SaveAs(_path);
                hotel.img_hotel = file2;


                // retira cifrão e ponto do valor 
                string diaria = hotel.diaria_hotel;
                diaria = String.Format("{0:C}", diaria);
                //diaria = diaria.Remove(0, 2);
                //diaria = Regex.Replace(diaria, "[^0-9]", "");
                hotel.diaria_hotel = diaria;

                // Inseri HOTEL
                acH.inserirHotel(hotel);
                ViewBag.sucesso = "Hotel Cadastrado com Sucesso";
                return View();

            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }

        }

        //---------------------- CADASTRO DE PACOTES --------------------------------

        // --------------- CADASTRO DO PACOTE PARTE 1 ----------------------------
        public ActionResult EscolhaHotel(Hotel hotel)
        {
            carregaHoteis(); // carrega a lista de HOTEIS
            return View(acH.ListarHotel());
        }
        [HttpPost]
        public ActionResult EscolhaHotel()
        {
            carregaHoteis(); // carrega a lista de HOTEIS


            if (Session["HotelEscolhido"] == null)
            {
                return View();
            }


            return RedirectToAction("EscolhaViagem");

        }

        // --------------- CADASTRO DO PACOTE PARTE 2 ----------------------------

        public ActionResult EscolhaViagem(Viagem viagem)
        {
            carregaViagens(); // carrega a lista de VIAGENS
            return View(acV.ListarViagem());
        }
        [HttpPost]
        public ActionResult EscolhaViagem()
        {
            Session["HotelEscolhido"] = Request["hotel"];


            carregaViagens();


            if (Request["viagem"] != null)
            {


                return RedirectToAction("PegaDados");
            }
            return View(acV.ListarViagem());
        }

        // --------------- PEGA DADOS PARA CADASTRO DO PACOTE  ----------------------------
        public ActionResult PegaDados(FormCollection frm)
        {
            Session["ViagemEscolhida"] = frm["viagem"];
            Session["dtChekin"] = Convert.ToDateTime(frm["dtChekin"]).ToString("yyyy/MM/dd");
            Session["dtChekout"] = Convert.ToDateTime(frm["dtChekout"]).ToString("yyyy/MM/dd");
            return RedirectToAction("CadastroPacote");
        }

        // --------------- CADASTRO DO PACOTE PARTE 3 ----------------------------
        public ActionResult CadastroPacote()
        {
            /* CARREGA LISTAS  */
            carregaCidades(); // carrega a lista de CIDADES
            carregaCidadesOrigem(); // carrega a lista de CIDADES PARA ORIGEM
            carregaHoteis(); // carrega a lista de HOTEIS
            carregaTransportes(); // carrega a lista de TRANSPORTES
            carregaTiposTransporte(); // carrega a lista de TIPOS DE TRANSPORTE
            carregaViagens(); // carrega a lista de VIAGENS
            carregaCategoria(); // carrega a lista de CATEGORIAS
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPacote(Pacote pacote, HttpPostedFileBase file, Hotel hotel, FormCollection frm)
        {
            Viagem viagem = new Viagem();
            /* CARREGA LISTAS  */
            carregaCidades(); // carrega a lista de CIDADES
            carregaCidadesOrigem(); // carrega a lista de CIDADES PARA ORIGEM
            carregaHoteis(); // carrega a lista de HOTEIS
            carregaTransportes(); // carrega a lista de TRANSPORTES
            carregaTiposTransporte(); // carrega a lista de TIPOS DE TRANSPORTE
            carregaViagens(); // carrega a lista de VIAGENS
            carregaCategoria(); // carrega a lista de CATEGORIAS


            /* RECEBE VALORES */
            string cdhotel = Session["HotelEscolhido"].ToString();
            string cdviagem = Session["ViagemEscolhida"].ToString();


            if (!ModelState.IsValid)
            {
                /* ATRIBUI VALORES AO PACOTE */
                pacote.cd_categoria = Request["categoria"];
                pacote.cd_cidDestino = Request["cidade"];
                pacote.cd_cidOrigem = Request["cidadeOrigem"];
                pacote.tipo_transporte = Request["tipotransporte"];
                pacote.dt_chekinHotel = Session["dtChekin"].ToString();
                pacote.dt_chekoutHotel = Session["dtChekout"].ToString();
                pacote.tipo_transporte = Request["tipo"];
                hotel.cd_hotel = cdhotel;
                pacote.cd_hotel = cdhotel;
                pacote.cd_viagem = cdviagem;
                viagem.cd_viagem = cdviagem;

                /* PEGA O PREÇO DO HOTEL E VIAGEM */
                acH.VerificaValor(hotel);
                acV.VerificaValor(viagem);

                /* CONTAGEM DOS DIAS */

                string dtChekin = Session["dtChekin"].ToString();   /* PEGA DATA DE CHEKIN */
                string dtChekout = Session["dtChekout"].ToString();   /* PEGA DATA DE CHEKOUT */

                /* FAZ A CONTA DOS DIAS NO HOTEL USANDO AS DATAS*/
                int totaldias = (DateTime.Parse(dtChekout).Subtract(DateTime.Parse(dtChekin))).Days;

                /* PASSA DADOS PARA PROXIMA CONTA */
                string diaria = hotel.diaria_hotel;
                string Vlviagem = viagem.vl_total;
                /* RETIRA PONTO VIRGULAS DOS DADOS EM MOEDA*/
                diaria = Regex.Replace(diaria, "[^0-9]", "");
                Vlviagem = Regex.Replace(Vlviagem, "[^0-9]", "");
                /* FAZ A CONTA DO VALOR TOTAL DO HOTEL ( DIAS * DIARIA)  */
                int vl_TotalHotel = (totaldias * Convert.ToInt32(diaria));
                /* FAZ A CONTA DO VALOR TOTAL DO PACOTE */
                double valorTotal = vl_TotalHotel + Convert.ToInt32(Vlviagem);
                /* ATRIBUI O VALOR TOTAL DO PACOTE A UMA VARIAVÉL */
                string valor = Convert.ToString(valorTotal);
                /* CONVERTEO VALOR TOTAL PARA MOEDA */
                valor = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor);
                pacote.vl_pacote = valor;
                   

                if (hotel.cd_hotel != null && viagem.cd_viagem != null)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        string arquivo = Path.GetFileName(file.FileName);
                        string file2 = "/ImagensPacote/" + Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/ImagensPacote"), arquivo);
                        file.SaveAs(_path);
                        pacote.img_pacote = file2;

                        acP.inserirPacote(pacote);
                        return RedirectToAction("Pacotes", "Sistema");

                    }
                    else
                    {
                        ViewBag.MessageError = "Para Continuar Adicione uma Imagem";
                        return View();
                    }
                }
            }
            else
            {
                return View();

            }
            return View();

        }


      
        //------------------ CARREGAMENTO / LISTAS -----------------------------

        public ActionResult HoteisPageIntermediaria()
        {
            ModelState.Clear();
            return View();
        }
        public ActionResult Hoteis(Hotel hotel)
        {
            ModelState.Clear();
            //string diaria = hotel.diaria_hotel;
            //diaria = Regex.Replace(diaria," /[^0 - 9.-] +/ g", "");
            //hotel.diaria_hotel = diaria;
            return View(acH.ListarHotel());
        }
        // --------------------- LISTA DE PACOTES ---------------------------
        public ActionResult Pacotes()
        {
            ModelState.Clear();

            return View(acP.ListarPacote());
        }
        // --------------------- LISTA DE VIAGENS ---------------------------
        public ActionResult Viagens()
        {
            ModelState.Clear();

            return View(acV.ListarViagem());
        }
        // --------------------- LISTA DE CLIENTES ---------------------------
        public ActionResult Clientes()
        {
            ModelState.Clear();
            return View(acC.ListarCliente());
        }
        // --------------------- LISTA DE FUNCIONÁRIOS ---------------------------
        public ActionResult Funcionarios()
        {
            ModelState.Clear();
            return View(acF.ListarFuncionario());
        }
        // --------------------- LISTA DE TRANSPORTES ---------------------------
        public ActionResult Transportes()
        {
            ModelState.Clear();
            return View(acT.ListarTransporte());
        }
        // --------------------- LISTA DE VENDAS ---------------------------
        public ActionResult Vendas()
        {
            ModelState.Clear();
            return View(acR.Vendas());
        }

        //----------------------------  DETALHES --------------------------------

        //------------------- DETALHES FUNCIONARIO ---------------------
        public ActionResult DetalhesFuncionario(string id, AcoesFuncionario func)
        {
            return View(func.GetDetalhesFuncionario().Find((smodel => smodel.rg == id)));
        }


        //------------------- DETALHES HOTEIS ---------------------
        public ActionResult DetalhesHoteis(string id, AcoesHotel hotel)
        {
            carregaCidades();
            return View(hotel.GetDetalhesHotel().Find((smodel => smodel.cd_hotel == id)));
        }
        //------------------- DETALHES VIAGENS ---------------------

        public ActionResult DetalhesViagens(string id, AcoesViagem viagem)
        {
            return View(viagem.GetDetalhesViagem().Find((smodel => smodel.cd_viagem == id)));
        }
        [HttpPost]
        public ActionResult DetalhesViagens(string id)
        {

            return View(acV.GetDestinoViagem().Find((smodel => smodel.cd_viagem == id)));
        }



        //------------------- DETALHES TRANSPORTES ---------------------

        public ActionResult DetalhesTransportes(string id, AcoesTransporte trans)
        {
            return View(trans.GetDetalhesTransporte().Find((smodel => smodel.cd_transporte == id)));
        }


        //------------------- DETALHES CLIENTES ---------------------

        public ActionResult DetalhesClientes(string id, AcoesCliente cliente)
        {
            return View(cliente.GetDetalhesCliente().Find((smodel => smodel.rg == id)));
        }



        //------------------- DETALHES PACOTES ---------------------

        public ActionResult DetalhesPacotes(string id, AcoesPacote pacote)
        {
            return View(pacote.GetDetalhesPacote().Find((smodel => smodel.cd_pacote == id)));
        }

        //------------------- DETALHES VENDAS ---------------------

        public ActionResult DetalhesVenda(RRViewModel reser, string id)
        {
            reser.cd_reserva = id;
            ViewBag.reserva = acR.ResumoReservas(reser);
            ViewBag.itens = acR.ItensReserva(reser);
            return View();
        }
        //------------------------------ ATUALIZAR  -----------------------------------------

        //----------------------- ATUALIZAR FUNCIONARIO --------------------


        public ActionResult AtualizaFuncionario(string id, Funcionario func)
        {

            if (id != null)
            {
                Session["rg"] = id;
                func.rg = id;
                acF.PegaDados(func);

                ViewBag.nome = func.nome;
                ViewBag.email = func.email;
                ViewBag.tel = func.telefone;
                ViewBag.cpf = func.CPF;
                ViewBag.rg = func.rg;
                ViewBag.tipo = func.tipo;

                ViewBag.senha = func.senha;
                ViewBag.cargo = func.cargo_func;
                return View();
            }
            else
            {
                return RedirectToAction("Funcionarios");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AtualizaFuncionario(Funcionario func, HttpPostedFileBase file, string id)
        {



            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
            string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
            file.SaveAs(_path);
            func.img = file2;
            //func.rg = Session["rg"].ToString();
            func.rg = id;


            acF.atualizarFuncionario(func);
            return RedirectToAction("Funcionarios");
        }


        //----------------------- ATUALIZAR HOTEIS --------------------

        public ActionResult AtualizaHotel(Hotel hotel, string id)
        {
            carregaCidades();
            if (id != null)
            {
                Session["cd"] = id;
                hotel.cd_hotel = id;
                acH.PegaDados(hotel);

                ViewBag.nome = hotel.nome_hotel;
                ViewBag.end = hotel.endereco_hotel;
                ViewBag.tel = hotel.telefone_hotel;
                ViewBag.des = hotel.descricao_hotel;
                ViewBag.diaria = hotel.diaria_hotel;

                return View();
            }
            else
            {
                return RedirectToAction("Hoteis");
            }



        }
        [HttpPost]
        public ActionResult AtualizaHotel(HttpPostedFileBase file, Hotel hotel)
        {
            carregaCidades();
            hotel.cd_cidade = Request["cidade"];
            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensHoteis/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensHoteis"), arquivo);
                file.SaveAs(_path);
                hotel.img_hotel = file2;


                // retira cifrão e ponto do valor 
                string diaria = hotel.diaria_hotel;
                diaria = Regex.Replace(diaria, "[^0-9]", "");
                hotel.diaria_hotel = diaria;

                hotel.cd_hotel = Session["cd"].ToString();
                acH.atualizarHotel(hotel);
                return RedirectToAction("Hoteis");

            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }
        }

        //----------------------- ATUALIZAR TRANSPORTES --------------------

        public ActionResult AtualizaTransporte(string id, Transporte trans)
        {

            carregaTiposTransporte(); // carrega a lista de Tipos de Transporte
            carregaCidades(); // carrega a lista de cidades
            if (id != null)
            {
                Session["cd"] = id;
                trans.cd_transporte = id;
                acT.PegaDados(trans);

                ViewBag.nome = trans.nome_transporte;

                return View();
            }
            else
            {
                return RedirectToAction("Transportes");
            }

        }
        [HttpPost]
        public ActionResult AtualizaTransporte(HttpPostedFileBase file, Transporte trans)
        {
            carregaTiposTransporte(); // carrega a lista de Tipos de Transporte
            carregaCidades(); // carrega a lista de cidades
            // ----------------------------------------------
            trans.tipo_transporte = Request["tipo"];
            trans.cidade_transporte = Request["cidade"];

            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensTransporte/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensTransporte"), arquivo);
                file.SaveAs(_path);
                trans.img_transporte = file2;
                // -------------------
                trans.cd_transporte = Session["cd"].ToString();
                acT.atualizarTransporte(trans);
                // -------------------
                return RedirectToAction("Transportes");

            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }
        }



        //----------------------- ATUALIZAR VIAGENS --------------------


        public ActionResult AtualizaViagem(string id, Viagem viagem)
        {
            carregaCidades();
            carregaTiposTransporte();
            carregaTransportes();
            carregaTransportesOrigem();
            if (id != null)
            {
                Session["cd"] = id;
                viagem.cd_viagem = id;
                acV.PegaDados(viagem);

                ViewBag.nome = viagem.nome_viagem;
                ViewBag.end = viagem.dt_ida;
                ViewBag.tel = viagem.dt_chegada;
                ViewBag.des = viagem.descricao;
                ViewBag.vl = viagem.vl_total;
                ViewBag.trans = viagem.tipo_transporte;

                return View();
            }
            else
            {
                return RedirectToAction("Viagens");
            }
        }
        [HttpPost]
        public ActionResult AtualizaViagem(Viagem viagem, HttpPostedFileBase file)
        {
            carregaCidades();
            carregaTiposTransporte();
            carregaTransportes();
            carregaTransportesOrigem();

            if (file != null && file.ContentLength > 0)
            {
                viagem.tipo_transporte = Request["tipo"]; // Atribui o Tipo escolhido ao campo tipo_transporte
                viagem.destino = Request["transportes"];  // Atribui o Transporte escolhido ao campo Destino
                viagem.origem = Request["transportesOrigem"];  // Atribui o Tipo escolhido ao campo  Origem

                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensViagem/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensViagem"), arquivo);
                file.SaveAs(_path);
                viagem.img_viagem = file2;
                // ---------------------------------------
                // retira cifrão e ponto do valor 
                string preco = viagem.vl_total;

                preco = Regex.Replace(preco, "[^0-9]", "");
                viagem.vl_total = preco;
                viagem.cd_viagem = Session["cd"].ToString();
                acV.atualizarViagem(viagem);
                return RedirectToAction("Viagens");
            }
            else
            {
                ViewBag.erro = "Para Continuar Adicione uma Imagem";
                return View();
            }
        }


        //-------------------------- EXCLUIR -----------------------------------------

        //-------------------EXCLUIR FUNCIONARIO ------------------------
        public ActionResult ExcluirFuncionario(int id)
        {
            try
            {

                if (acF.excluirFuncionario(id))
                {
                    ViewBag.AlertMsg = "Funcionário excluído com sucesso";
                }
                return RedirectToAction("Funcionarios");
            }
            catch
            {
                return View();
            }
        }

        //-------------------EXCLUIR HOTEL ------------------------
        public ActionResult ExcluiHotel(int id)
        {
            try
            {

                if (acH.excluirHotel(id))
                {
                    ViewBag.AlertMsg = "Hotel excluído com sucesso";
                }
                return RedirectToAction("Hoteis");
            }
            catch
            {
                return View();
            }
        }

        //-------------------EXCLUIR Viagem ------------------------
        public ActionResult ExcluiViagem(int id)
        {
            try
            {

                if (acV.excluirViagem(id))
                {
                    ViewBag.AlertMsg = "Viagem excluída com sucesso";
                }
                return RedirectToAction("Viagens");
            }
            catch
            {
                return View();
            }
        }


        //-------------------EXCLUIR PACOTE ------------------------
        public ActionResult ExcluiPacote(int id)
        {
            try
            {

                if (acP.excluirPacote(id))
                {
                    ViewBag.AlertMsg = "Pacote excluído com sucesso";
                }
                return RedirectToAction("Pacotes");
            }
            catch
            {
                return View();
            }
        }

        //-------------------EXCLUIR TRANSPORTE ------------------------
        public ActionResult ExcluiTransporte(int id)
        {
            try
            {

                if (acT.excluirTransporte(id))
                {
                    ViewBag.AlertMsg = "Transporte excluído com sucesso";
                }
                return RedirectToAction("Transportes");
            }
            catch
            {
                return View();
            }
        }



    }
}