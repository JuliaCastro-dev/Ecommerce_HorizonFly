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

        public List<Count> ListarQuantidade()
        {
            List<Count> QTList = new List<Count>();

            MySqlCommand cmd = new MySqlCommand("call ChamaResumo()", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                QTList.Add(

                     new Count
                     {
                         quantidadeFuncionarios = Convert.ToString(dr["Funcionários"]),
                         quantidadeClientes = Convert.ToString(dr["Clientes"]),
                         quantidadePacotes = Convert.ToString(dr["Pacotes"]),
                         quantidadeReservas = Convert.ToString(dr["Vendas"]),
                         quantidadeTransportes = Convert.ToString(dr["Transportes"]),
                         quantidadeViagens = Convert.ToString(dr["Viagens"]),
                         quantidadeHoteis = Convert.ToString(dr["Hoteis"])


                     });
            }
            return QTList;
        }

    }
}

