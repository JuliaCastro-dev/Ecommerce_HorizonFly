﻿using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesReserva
    {
        conexao con = new conexao();
        public void inserirReserva(Reserva reserva)

        {

            MySqlCommand cmd = new MySqlCommand("insert into Reserva(cd_reserva, CPF, cd_cartao,vl_total,  Status_Reserva, )" +
                "values(@cdR, @cpf, @cdC, @vlTotal, 1)", con.MyConectarBD());



            cmd.Parameters.Add("@cdR", MySqlDbType.VarChar).Value = reserva.cd_reserva;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = reserva.cpf_cliente;
            cmd.Parameters.Add("@cdC", MySqlDbType.VarChar).Value = reserva.cd_cartao;
            cmd.Parameters.Add("@vlTotal", MySqlDbType.VarChar).Value = reserva.vl_total;
            cmd.Parameters.Add("@StaReserva", MySqlDbType.VarChar).Value = reserva.Status_Reserva;



            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();
        }


        public List<Reserva> ListarReserva()
        {
            List<Reserva> ResList = new List<Reserva>();

            MySqlCommand cmd = new MySqlCommand("select * from Reserva", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ResList.Add(

                     new Reserva
                     {
                         cd_reserva = Convert.ToString(dr["cd_reserva"]),
                         cpf_cliente = Convert.ToString(dr["CPF"]),
                         cd_cartao = Convert.ToString(dr["cd_cartao"]),
                         vl_total = Convert.ToDouble(dr["vl_total"]),
                         Status_Reserva = Convert.ToString(dr["Status_Reserva"]),


                     });
            }
            return ResList;
        }

        public bool atualizarReserva(Reserva reser)
        {

            MySqlCommand cmd = new MySqlCommand("update Reserva set cd_cartao=@cd_cartao,vl_total=@vl_total,Status_Reserva=@Status_Reserva where cd_reserva=@reserva,", con.MyConectarBD());



            cmd.Parameters.Add("@cd_reserva", MySqlDbType.VarChar).Value = reser.cd_reserva;

            cmd.Parameters.Add("@cd_cartao", MySqlDbType.VarChar).Value = reser.cd_cartao;

            cmd.Parameters.Add("@vl_total", MySqlDbType.VarChar).Value = reser.vl_total;

            cmd.Parameters.Add("@Status_Reserva", MySqlDbType.VarChar).Value = reser.Status_Reserva;




            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }


        public bool excluirReserva(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Reserva where cd_reserva = @cd", con.MyConectarBD());

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