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
                MySqlCommand cmd = new MySqlCommand("select * from Cidade order by cidade;", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    cidade.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
                con.Open();
            }


            ViewBag.cidade = new SelectList(cidade, "Value", "Text");
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

            if (ModelState.IsValid)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
                file.SaveAs(_path);
                func.img = file2;
                acF.inserirFuncionario(func);
                return RedirectToAction("Funcionarios", "Sistema");

            }
            return View();
        }

        //-------------- CADASTRO DE HOTÉIS -----------

        public ActionResult CadastroHotel(Hotel hotel)
        {
            carregaCidades();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastroHotel(Hotel hotel, AcoesHotel ach, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensFuncionario/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensFuncionario"), arquivo);
                file.SaveAs(_path);
                hotel.img_hotel = file2;
                acH.inserirHotel(hotel);
                return RedirectToAction("Hoteis", "Sistema");

            }
            return View();
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

            if (ModelState.IsValid)
            {
                string arquivo = Path.GetFileName(file.FileName);
                string file2 = "/ImagensPacote/" + Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/ImagensPacote"), arquivo);
                file.SaveAs(_path);
                pacote.img_pacote = file2;
                acP.inserirPacote(pacote);
                return RedirectToAction("Pacotes", "Sistema");

            }
            return View();
        }


        //-------------- DASHBOARDS -----------
        public ActionResult Dashboard()
        {
            ModelState.Clear();
            ViewBag.nome = Session["nome"];
            ViewBag.img = Session["img"];
           
            return View(acS.ListarQuantidade());
        }

        //-------------- VIEWS DE LISTA/ALTERAÇÃO E CONSULTA -----------
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