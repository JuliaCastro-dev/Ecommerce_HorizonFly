using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Ecommerce.Acoes
{
    public class AcoesHotel
    {
        conexao con = new conexao();
        public static string cidade;
        public static string cd_cidade;

        public static string valor;
        public void inserirHotel(Hotel hotel)

        {

            MySqlCommand cmd = new MySqlCommand("insert into Hotel(cd_cidade, nome_hotel, diaria_hotel, descricao_hotel, endereco_hotel, telefone_hotel , img_hotel )" +
                "values(@cid, @hotel, @diaria, @descri, @end , @tel, @img ) ", con.MyConectarBD());



            cmd.Parameters.Add("@cid", MySqlDbType.VarChar).Value = hotel.cd_cidade;
            cmd.Parameters.Add("@hotel", MySqlDbType.VarChar).Value = hotel.nome_hotel;
            cmd.Parameters.Add("@diaria", MySqlDbType.VarChar).Value = hotel.diaria_hotel;
            cmd.Parameters.Add("@descri", MySqlDbType.VarChar).Value = hotel.descricao_hotel;
            cmd.Parameters.Add("@end", MySqlDbType.VarChar).Value = hotel.endereco_hotel;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = hotel.telefone_hotel;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = hotel.img_hotel;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }
       
        public List<Hotel> ListarHotel()
        {
            List<Hotel> HotList = new List<Hotel>();

            MySqlCommand cmd = new MySqlCommand("select * from Hotel", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                HotList.Add(

                     new Hotel
                     {
                         cd_hotel = Convert.ToString(dr["cd_hotel"]),
                         cd_cidade = Convert.ToString(dr["cd_cidade"]),
                         nome_hotel = Convert.ToString(dr["nome_hotel"]),
                         descricao_hotel = Convert.ToString(dr["descricao_hotel"]),
                         telefone_hotel = Convert.ToString(dr["telefone_hotel"]),
                         endereco_hotel = Convert.ToString(dr["endereco_hotel"]),
                         diaria_hotel = Convert.ToString(dr["diaria_hotel"]),
                         img_hotel = Convert.ToString(dr["img_hotel"])

                     }); ;
            }
            return HotList;
        }


        public void VerificaValor(Hotel hotel)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Hotel where cd_hotel = @cd", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = hotel.cd_hotel;


            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {

                while (leitor.Read())
                {
                    hotel.cd_hotel= Convert.ToString(leitor["cd_hotel"]);
                    hotel.nome_hotel = Convert.ToString(leitor["nome_hotel"]);
                    hotel.diaria_hotel = Convert.ToString(leitor["diaria_hotel"]);


                }
            }
            else
            {
               
                hotel.nome_hotel = null;
               hotel.diaria_hotel = null;


            }

        }





        public bool atualizarHotel(Hotel hot)
        {

            MySqlCommand cmd = new MySqlCommand("update Hotel set cd_cidade=@cd_cidade,nome_hotel=@nome_hotel, descricao_hotel=@descricao_hotel,telefone_hotel=@telefone_hotel,endereco_hotel=@endereco_hotel,diaria_hotel=@diaria_hotel,img_hotel=@img_hotel  where cd_hotel=@hotel,", con.MyConectarBD());


            cmd.Parameters.Add("@cd_hotel", MySqlDbType.VarChar).Value = hot.cd_hotel;
            cmd.Parameters.Add("@cd_cidade", MySqlDbType.VarChar).Value = hot.cd_cidade;

            cmd.Parameters.Add("@nome_hotel", MySqlDbType.VarChar).Value = hot.nome_hotel;

            cmd.Parameters.Add("@descricao_hotel", MySqlDbType.VarChar).Value = hot.descricao_hotel;

            cmd.Parameters.Add("@telefone_hotel", MySqlDbType.VarChar).Value = hot.telefone_hotel;

            cmd.Parameters.Add("@endereco_hotel", MySqlDbType.VarChar).Value = hot.endereco_hotel;

            cmd.Parameters.Add("@diaria_hotel", MySqlDbType.VarChar).Value = hot.diaria_hotel;

            cmd.Parameters.Add("@img_hotel", MySqlDbType.VarChar).Value = hot.img_hotel;


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }


        public bool excluirHotel(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Hotel where cd_hotel = @cd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public void RetornaCidade(Hotel hotel)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Cidade where cd_cidade = @cd ", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = hotel.cd_cidade;


            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();
            con.MyDesconectarBD();
            if (leitor.HasRows)
            {

                while (leitor.Read())
                {
                   cidade = Convert.ToString(leitor["cidade"]);
                   cd_cidade = Convert.ToString(leitor["cd_cidade"]);

                }
            }
            
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
