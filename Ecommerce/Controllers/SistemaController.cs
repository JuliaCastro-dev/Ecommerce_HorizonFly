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
        public ActionResult CadastroPacote(Pacote pacote, HttpPostedFileBase file, Hotel hotel, Viagem viagem)
        {
            carregaCidades();
            carregaHoteis();
            carregaTiposTransporte();
            carregaTransportes();
            carregaViagens();

            carregaCategoria();
            carregaCidadesOrigem();



            if (!ModelState.IsValid)
            {


                pacote.cd_categoria = Request["categoria"];
                pacote.cd_cidDestino = Request["cidade"];
                pacote.cd_cidOrigem = Request["cidade"];
                string cdhotel = Request["hotel"];
                string cdviagem = Request["viagem"];
                pacote.tipo_transporte = Request["tipo"];

                hotel.cd_hotel = cdhotel;
                pacote.cd_hotel = cdhotel;

                viagem.cd_viagem = cdviagem;
                pacote.cd_viagem = cdviagem;

                acH.ListarHotelValor(hotel);
                acV.ListarViagemValor(viagem);

                if (AcoesHotel.valor != null && AcoesViagem.valor != null)
                {
                    ViewBag.vlHotel = AcoesHotel.valor;
                    ViewBag.vlviagem = AcoesViagem.valor;
                    


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
            return View(func.GetDetalhesFuncionario().Find((smodel => smodel.CPF == id)));
        }

        //------------------- DETALHES HOTEIS ---------------------
        public ActionResult DetalhesHoteis(string id, AcoesHotel hotel)
        {
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
            return View(cliente.GetDetalhesCliente().Find((smodel => smodel.CPF == id)));
        }






    }
}