using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesItens
    {
        conexao con = new conexao();
        public void inserirItem( Itens cm )
        {
            MySqlCommand cmd = new MySqlCommand("insert into ItensReserva values(default,@cdpacote, @cdreserva, @unit , @parcial, @qt , 1, @cpf)", con.MyConectarBD());

            cmd.Parameters.Add("@cdpacote", MySqlDbType.VarChar).Value = cm.cd_pacote;
            cmd.Parameters.Add("@cdreserva", MySqlDbType.VarChar).Value = cm.cd_reserva;
            cmd.Parameters.Add("@unit", MySqlDbType.VarChar).Value = cm.vl_unit;
            cmd.Parameters.Add("@parcial", MySqlDbType.VarChar).Value = cm.vl_parcial;
            cmd.Parameters.Add("@qt", MySqlDbType.VarChar).Value = cm.qt;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cm.CPF;
            cmd.ExecuteNonQuery();
            con.MyDesconectarBD();
        }

    }
}