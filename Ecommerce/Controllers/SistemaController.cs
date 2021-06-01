using Ecommerce.Acoes;
using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Ecommerce.Controllers
{
    public class SistemaController : Controller
    {

        AcoesFuncionario acF = new AcoesFuncionario();
        AcoesCliente acC = new AcoesCliente();
        AcoesCartao acCar = new AcoesCartao();
        AcoesHotel acH = new AcoesHotel();
        AcoesPacote acP = new AcoesPacote();
        AcoesReserva acR = new AcoesReserva();
        AcoesSistema acS = new AcoesSistema();
        AcoesTransporte acT = new AcoesTransporte();
        AcoesViagem acV = new AcoesViagem();

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


            ViewBag.cidade = new SelectList(categoria, "Value", "Text");
        }


        public void carregaTiposTransporte()
        {
            List<SelectListItem>tipo= new List<SelectListItem>();

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
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.hotel = new SelectList(hotel, "Value", "Text");
        }

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
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.viagem = new SelectList(Viagem, "Value", "Text");
        }

        public void carregaTransportes()
        {
            List<SelectListItem> Transporte = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Transporte order by nome_transporte;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Transporte.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.transporte = new SelectList(Transporte, "Value", "Text");
        }
        //-------------- VIEW ESCOLHA DE CONTAS CLIENTE E FUNCIONÁRIO -----------
        public ActionResult Contas()
        {

            return View();
        }
        //-------------- VIEWS CADASTRO -----------

        //-------------- CADASTRO FUNCIONÁRIOS -----------
        public ActionResult CadastroFuncionario()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroFuncionario(Funcionario func, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
                file.SaveAs(_path);
                func.img = file2;
                acF.inserirFuncionario(func);
                return RedirectToAction("Funcionarios", "Sistema");

            }
            else
            {
                acF.inserirFuncionario(func);
                return RedirectToAction("Funcionarios", "Sistema");
            }
            
        }


        //-------------- CADASTRO FUNCIONÁRIOS -----------
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

        //-------------- CADASTRO DE HOTÉIS -----------
        public ActionResult CadastroHoteis()
        {
            
            carregaCidades(); // carrega a lista de cidades
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroHoteis(Hotel hotel, HttpPostedFileBase file)
        {
            ModelState.Clear();
            
            carregaCidades(); // carrega a lista de cidades
            hotel.cd_cidade = Request["cidade"];

            if (file != null && file.ContentLength > 0)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensTransporte/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensTransporte"), arquivo);
                file.SaveAs(_path);
                hotel.img_hotel = file2;
                // pega nome da cidade escolhida 
                acH.RetornaCidade(hotel);
                Session["cidadeEscolhida"] = AcoesHotel.cidade.ToString();
                Session["cdcidadeEscolhida"] = AcoesHotel.cd_cidade.ToString();
                // Inseri hOTEL
                hotel.cd_cidade = Session["cdcidadeEscolhida"].ToString();
                hotel.cidade_hotel = Session["cidadeEscolhida"].ToString();
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

        //-------------- CADASTRO DE PACOTES -----------

        public ActionResult CadastroPacote(Pacote pacote)
        {
            carregaCidades();
            carregaHoteis();
            carregaTransportes();
            carregaViagens();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroPacote(Pacote pacote, HttpPostedFileBase file)
        {
            carregaCidades();
            carregaHoteis();
            carregaTransportes();
            carregaViagens();

            pacote.cd_cidDestino = Request["cidade"];
            pacote.cd_cidOrigem = Request["cidade"];
            pacote.cd_hotel = Request["hotel"];
            pacote.cd_transporte = Request["transporte"];
            pacote.cd_viagem = Request["viagem"];

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
           
            return View();
        }
        public ActionResult Hoteis()
        {
            ModelState.Clear();
            return View(acH.ListarHotel());
        }
        public ActionResult Pacotes()
        {

            return View();
        }
        public ActionResult Clientes()
        {

            return View();
        }
        public ActionResult Funcionarios()
        {

            return View();
        }
        public ActionResult Transportes()
        {

            return View();
        }






    }
}