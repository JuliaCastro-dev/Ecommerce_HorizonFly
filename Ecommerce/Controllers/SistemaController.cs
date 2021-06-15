using Ecommerce.Acoes;
using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

                preco = Regex.Replace(preco, "[^0-9]", "");
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
                diaria = Regex.Replace(diaria, "[^0-9]", "");
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

        // VIEW ESCOLHA DE HOTEL 
        public ActionResult EscolhaHotel(Hotel hotel)
        {
            carregaHoteis();
            return View(acH.ListarHotel());
        }
        [HttpPost]
        public ActionResult EscolhaHotel()
        {
            carregaHoteis();


            if (Session["HotelEscolhido"] == null)
            {
                return View();
            }


            return RedirectToAction("EscolhaViagem");

        }


        public ActionResult EscolhaViagem(Viagem viagem)
        {
            carregaViagens();
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


        public ActionResult PegaDados(FormCollection frm)
        {
            Session["ViagemEscolhida"] = frm["viagem"];
            Session["dtChekin"] = Convert.ToDateTime(frm["dtChekin"]).ToString("yyyy/MM/dd");
            Session["dtChekout"] = Convert.ToDateTime(frm["dtChekout"]).ToString("yyyy/MM/dd");
            return RedirectToAction("CadastroPacote");
        }


        public ActionResult CadastroPacote()
        {

            carregaCidades();
            carregaCidadesOrigem();
            carregaHoteis();
            carregaTransportes();
            carregaTiposTransporte();
            carregaViagens();

            carregaCategoria();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPacote(Pacote pacote, HttpPostedFileBase file, Hotel hotel, FormCollection frm)
        {
            Viagem viagem = new Viagem();
            /* CARREGA LISTAS  */
            carregaCidades();
            carregaTiposTransporte();
            carregaTransportes();
            carregaCategoria();
            carregaCidadesOrigem();


            /* RECEBE VALORES */



            string cdhotel = Session["HotelEscolhido"].ToString();
            string cdviagem = Session["ViagemEscolhida"].ToString();


            if (!ModelState.IsValid)
            {
                /* ATRIBUI VALORES AO PACOTE */
                pacote.cd_categoria = Request["categoria"];
                pacote.cd_cidDestino = Request["cidade"];
                pacote.cd_cidOrigem = Request["cidade"];
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
                string dtChekin = frm["dtChekin"];
                string dtChekout = frm["dtChekout"];

                int chekin = Convert.ToInt16(dtChekin);
                int chekout = Convert.ToInt16(dtChekout);
                int dias = chekin - chekout / 24 * 3600 * 1000;

                int vl_TotalHotel = (dias * (Convert.ToInt32(hotel.diaria_hotel)));
                int valorTotal = vl_TotalHotel + Convert.ToInt32(viagem.vl_total);

                pacote.vl_pacote = valorTotal.ToString();
                if (hotel.cd_hotel != null && viagem.cd_viagem != null)
                {



                    if (file != null && file.ContentLength > 0)
                    {
                        string arquivo = Path.GetFileName(file.FileName);
                        string file2 = "/ImagensPacote/" + Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/ImagensPacote"), arquivo);
                        file.SaveAs(_path);
                        pacote.img_pacote = file2;

                        // retira cifrão e ponto do valor 
                        string preco = pacote.vl_pacote;
                        preco = Regex.Replace(preco, "[^0-9]", "");
                        pacote.vl_pacote = preco;


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


        //-------------- DASHBOARDS -----------
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

        //-------------- VIEWS DE CARREGAMENTO/ LISTA/ALTERAÇÃO E CONSULTA -----------

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
        public ActionResult Pacotes()
        {
            ModelState.Clear();

            return View(acP.ListarPacote());
        }
        public ActionResult Viagens()
        {
            ModelState.Clear();

            return View(acV.ListarViagem());
        }
        public ActionResult Clientes()
        {
            ModelState.Clear();
            return View(acC.ListarCliente());
        }
        public ActionResult Funcionarios()
        {
            ModelState.Clear();
            return View(acF.ListarFuncionario());
        }
        public ActionResult Transportes()
        {
            ModelState.Clear();
            return View(acT.ListarTransporte());
        }

        //------------------- PAGINAS DE DETALHES ---------------------

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



        //------------------- DETALHES TRANSPORTES ---------------------

        public ActionResult DetalhesTransportes(string id, AcoesTransporte trans)
        {
            return View(trans.GetDetalhesTransporte().Find((smodel => smodel.cd_transporte == id)));
        }


        //------------------- DETALHES Cliente ---------------------

        public ActionResult DetalhesClientes(string id, AcoesCliente cliente)
        {
            return View(cliente.GetDetalhesCliente().Find((smodel => smodel.rg == id)));
        }



        //------------------- DETALHES PACOTES ---------------------

        public ActionResult DetalhesPacotes(string id, AcoesPacote pacote)
        {
            return View(pacote.GetDetalhesPacote().Find((smodel => smodel.cd_pacote == id)));
        }


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


        //----------------------- ATUALIAR HOTEIS --------------------

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

        //----------------------- ATUALIAR TRANSPORTES --------------------


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
        public ActionResult AtualizaTransporte( HttpPostedFileBase file, Transporte trans)
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



        //----------------------- ATUALIAR VIAGENS --------------------


        public ActionResult AtualizaViagem(string id, Viagem viagem )
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

        //-------------------EXCLUIR CLIENTE ------------------------
        public ActionResult ExcluirCliente(int id)
        {
            try
            {

                if (acC.excluirCliente(id))
                {
                    ViewBag.AlertMsg = "Cliente excluído com sucesso";
                }
                return RedirectToAction("Clientes");
            }
            catch
            {
                return View();
            }
        }


    }
}