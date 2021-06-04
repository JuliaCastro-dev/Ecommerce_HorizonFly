using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesPacote
    {
        conexao con = new conexao();

        public void inserirPacote(Pacote pacote)
        {

            MySqlCommand cmd = new MySqlCommand("insert into Pacote(cd_pacote, cd_viagem, cd_hotel, cd_cidOrigem, cd_cidDestino, nm_pacote, tipo_trasnporte , descricao_pacote, dtChekin_hotel, dtChekout_hotel, img_pacote, vl_pacote)" +
                "values(@pac, @Viag, @hot, @cidO, @cidD, @nmPac , @tpTrans, @desc, @dtChekin, @dtChekout, @img, @valP )", con.MyConectarBD());

            cmd.Parameters.Add("@pac", MySqlDbType.VarChar).Value = pacote.cd_pacote;
            cmd.Parameters.Add("@Viag", MySqlDbType.VarChar).Value = pacote.cd_viagem;
            cmd.Parameters.Add("@hot", MySqlDbType.VarChar).Value = pacote.cd_hotel;
            cmd.Parameters.Add("@cidO", MySqlDbType.VarChar).Value = pacote.cd_cidOrigem;
            cmd.Parameters.Add("@cidD", MySqlDbType.VarChar).Value = pacote.cd_cidDestino;
            cmd.Parameters.Add("@nmPac", MySqlDbType.VarChar).Value = pacote.nome_pacote;
            cmd.Parameters.Add("@tpTrans", MySqlDbType.VarChar).Value = pacote.tipo_transporte;
            cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = pacote.descricao_pacote;
            cmd.Parameters.Add("@dtChekin", MySqlDbType.VarChar).Value = pacote.dt_chekinHotel;
            cmd.Parameters.Add("@dtChekout", MySqlDbType.VarChar).Value = pacote.dt_chekoutHotel;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = pacote.img_pacote;
            cmd.Parameters.Add("@valP", MySqlDbType.VarChar).Value = pacote.vl_pacote;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }

        public List<Pacote> ListarPacote()
        {
            List<Pacote> PacList = new List<Pacote>();

            MySqlCommand cmd = new MySqlCommand("select * from Pacote", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                PacList.Add(

                     new Pacote
                     {
                         cd_pacote = Convert.ToString(dr["cd_pacote"]),
                         nome_pacote = Convert.ToString(dr["nome_pacote"]),
                         cd_cidDestino = Convert.ToString(dr["cd_cidDestino"]),
                         cd_cidOrigem = Convert.ToString(dr["cd_cidOrigem"]),
                         cd_hotel = Convert.ToString(dr["cd_hotel"]),
                         cd_transporte = Convert.ToString(dr["cd_transporte"]),
                         cd_viagem = Convert.ToString(dr["cd_viagem"]),
                         dt_chekinHotel = Convert.ToString(dr["dt_chekinHotel"]),
                         dt_chekoutHotel = Convert.ToString(dr["dt_chekoutHotel"]),
                         descricao_pacote = Convert.ToString(dr["descricao_pacote"]),
                         tipo_transporte = Convert.ToString(dr["tipo_transporte"]),
                         vl_pacote = Convert.ToString(dr["vl_pacote"]),
                         img_pacote = Convert.ToString(dr["img_pacote"])

                     });
            }
            return PacList;
        }
        public void ProcuraPacotes(Pacote pac)
        {

            MySqlCommand cmd = new MySqlCommand("", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = pac.cd_cidDestino;
        

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }

        public bool atualizarPacote(Pacote pac)
        {

            MySqlCommand cmd = new MySqlCommand("update Pacote set cd_viagem=@cd_viagem,cd_hotel=@cd_hotel,cd_cidOrigem=@cd_cidOrigem,cd_transporte=@cd_transporte,cd_cidDestino=@cd_cidDestino,nome_pacote=@nome_pacote,tipo_transporte=@tipo_transporte,descricao_pacote=@descricao_pacote,dtChekin_hotel=@dtChekin_hotel, dtChekout_hotel=@dtChekout_hotel,img_pacote=@img_pacote,vl_pacote=@vl_pacote  where cd_pacote=@pacote,", con.MyConectarBD());

            cmd.Parameters.Add("@pacote", MySqlDbType.VarChar).Value = pac.cd_pacote;

            cmd.Parameters.Add("@cd_viagem", MySqlDbType.VarChar).Value = pac.cd_viagem;

            cmd.Parameters.Add("@cd_hotel", MySqlDbType.VarChar).Value = pac.cd_hotel;

            cmd.Parameters.Add("@cd_cidOrigem", MySqlDbType.VarChar).Value = pac.cd_cidOrigem;

            cmd.Parameters.Add("@cd_transporte", MySqlDbType.VarChar).Value = pac.cd_transporte;

            cmd.Parameters.Add("@cd_cidDestino", MySqlDbType.VarChar).Value = pac.cd_cidDestino;

            cmd.Parameters.Add("@nome_pacote", MySqlDbType.VarChar).Value = pac.nome_pacote;

            cmd.Parameters.Add("@tipo_transporte", MySqlDbType.VarChar).Value = pac.tipo_transporte;

            cmd.Parameters.Add("@descricao_pacote", MySqlDbType.VarChar).Value = pac.descricao_pacote;

            cmd.Parameters.Add("@dtChekin_hotel", MySqlDbType.VarChar).Value = pac.dt_chekinHotel;

            cmd.Parameters.Add("@dtChekout_hotel", MySqlDbType.VarChar).Value = pac.dt_chekoutHotel;

            cmd.Parameters.Add("@img_pacote", MySqlDbType.VarChar).Value = pac.img_pacote;

            cmd.Parameters.Add("@vl_pacote", MySqlDbType.VarChar).Value = pac.vl_pacote;


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }

        public bool excluirPacote(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Pacote where cd_pacote = @cd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}