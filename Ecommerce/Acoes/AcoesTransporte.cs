using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesTransporte
    {

        conexao con = new conexao();
        public void inserirTransporte(Transporte tran)

        {

            MySqlCommand cmd = new MySqlCommand("insert into Transporte(cidade_transporte, nome_transporte, cd_tipotransporte, img_transporte )" +
                "values(@cid, @transporte, @tipo, @img )", con.MyConectarBD());


            cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = tran.cidade_transporte;
            cmd.Parameters.Add("@transporte", MySqlDbType.VarChar).Value = tran.nome_transporte;
            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = tran.tipo_transporte;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = tran.img_transporte;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }

        public List<Transporte> ListarTransporte()
        {
            List<Transporte> TransList = new List<Transporte>();

            MySqlCommand cmd = new MySqlCommand("select * from Transporte order by nome_transporte", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                TransList.Add(

                     new Transporte
                     {
                         cd_transporte = Convert.ToString(dr["cd_transporte"]),
                         cidade_transporte = Convert.ToString(dr["cidade_transporte"]),
                         nome_transporte = Convert.ToString(dr["nome_transporte"]),
                       
                         img_transporte = Convert.ToString(dr["img_transporte"])

                     });
            }
            return TransList;
        }

        public bool atualizarTransporte(Transporte trans)
        {

            MySqlCommand cmd = new MySqlCommand("update Transporte set cidade_transporte=@cidade_transporte,nome_transporte=@nome_transporte,tipo_transporte=@tipo_transporte,img_transporte=@img_transporte where cd_transporte=@transporte,", con.MyConectarBD());



            cmd.Parameters.Add("@cidade_transporte", MySqlDbType.VarChar).Value = trans.cidade_transporte;

            cmd.Parameters.Add("@nome_transporte", MySqlDbType.VarChar).Value = trans.nome_transporte;

            cmd.Parameters.Add("@tipo_transporte", MySqlDbType.VarChar).Value = trans.tipo_transporte;

            cmd.Parameters.Add("@img_transporte", MySqlDbType.VarChar).Value = trans.img_transporte;




            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }


        public bool excluirTransporte(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Transporte where cd_transporte = @cd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }



        public List<Hotel> GetDetalhesHotel()
        {
            List<Hotel> Hotellist = new List<Hotel>();

            MySqlCommand cmd = new MySqlCommand("select * from hoteis", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Hotellist.Add(
                      new Hotel
                      {
                          cd_hotel = Convert.ToString(dr["cd_hotel"]),
                          nome_hotel = Convert.ToString(dr["nome_hotel"]),
                          cidade_hotel = Convert.ToString(dr["cidade"]),
                          telefone_hotel = Convert.ToString(dr["telefone_hotel"]),
                          endereco_hotel = Convert.ToString(dr["endereco_hotel"]),
                          diaria_hotel = Convert.ToString(dr["diaria_hotel"]),
                          descricao_hotel = Convert.ToString(dr["descricao_hotel"]),
                          img_hotel = Convert.ToString(dr["img_hotel"])

                      });
            }
            return Hotellist;
        }




    }
}