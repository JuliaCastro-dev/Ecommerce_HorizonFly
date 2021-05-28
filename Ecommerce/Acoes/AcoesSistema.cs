using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesSistema
    {
        conexao con = new conexao();
        public List<Count> ListarQuantidadeFuncionarios()
        {
            List<Count> QTFunc = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM Funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTFunc.Add(

                       new Count
                       {
                           quantidadeFuncionarios = Convert.ToString(dr[0])

                       });
            }
            return QTFunc;
        }


        public List<Count> ListarQuantidadeClientes()
        {
            List<Count> QTCli = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM Cliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTCli.Add(
                       new Count
                       {
                           quantidadeClientes = Convert.ToString(dr[0])

                       });
            }
            return QTCli;
        }


        public List<Count> ListarQuantidadeViagens()
        {
            List<Count> QTVi = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM Viagem", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTVi.Add(
                       new Count
                       {
                           quantidadeViagens = Convert.ToString(dr[0])

                       });
            }
            return QTVi;
        }

        public List<Count> ListarQuantidadeTransportes()
        {
            List<Count> QTT = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM Transporte", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTT.Add(
                       new Count
                       {
                           quantidadeTransportes = Convert.ToString(dr[0])

                       });
            }
            return QTT;
        }

        public List<Count> ListarQuantidadePacotes()
        {
            List<Count> QTP = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM Pacote", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTP.Add(
                       new Count
                       {
                           quantidadePacotes = Convert.ToString(dr[0])

                       });
            }
            return QTP;
        }

        public List<Count> ListarQuantidadeReservas()
        {
            List<Count> QTR = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM Reserva", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTR.Add(
                       new Count
                       {
                           quantidadeReservas = Convert.ToString(dr[0])

                       });
            }
            return QTR;
        }

        public List<Count> ListarQuantidadeHoteis()
        {
            List<Count> QTH = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("Select count(*) FROM HOTEL", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTH.Add(
                       new Count
                       {
                           quantidadeHoteis = Convert.ToString(dr[0])

                       });
            }
            return QTH;
        }


    }
}

