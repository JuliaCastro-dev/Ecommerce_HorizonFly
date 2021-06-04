using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesViagem
    {
        conexao con = new conexao();

        public static string valor;
        //INSERIR NOVA VIAGEM
        public void inserirViagem(Viagem viagem)
        {

            MySqlCommand cmd = new MySqlCommand("insert into Viagem(cd_viagem, nome_viagem, cd_tipotransporte, origem,destino,  dt_ida, dt_chegada,descricao, vl_total, img_viagem)" +
                "values(@cdV, @nm, @tpTrans, @orig, @dest, @dtI, @dtC , @desc, @vlTotal, @img )", con.MyConectarBD());



            cmd.Parameters.Add("@cdV", MySqlDbType.VarChar).Value = viagem.cd_viagem;
            cmd.Parameters.Add("@nm", MySqlDbType.VarChar).Value = viagem.nome_viagem;
            cmd.Parameters.Add("@tpTrans", MySqlDbType.VarChar).Value = viagem.tipo_transporte;
            cmd.Parameters.Add("@orig", MySqlDbType.VarChar).Value = viagem.origem;
            cmd.Parameters.Add("@dest", MySqlDbType.VarChar).Value = viagem.destino;
            cmd.Parameters.Add("@dtI", MySqlDbType.VarChar).Value = viagem.dt_ida;
            cmd.Parameters.Add("@dtC", MySqlDbType.VarChar).Value = viagem.dt_chegada;
            cmd.Parameters.Add("@desc", MySqlDbType.VarChar).Value = viagem.descricao;
            cmd.Parameters.Add("@vlTotal", MySqlDbType.VarChar).Value = viagem.vl_total;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = viagem.img_viagem;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }


        //LISTAR VIAGENS
        public List<Viagem> ListarViagem()
        {
            List<Viagem> ViList = new List<Viagem>();

            MySqlCommand cmd = new MySqlCommand("select * from Viagem", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                ViList.Add(

                     new Viagem
                     {
                         origem = Convert.ToString(dr["origem"]),
                         destino = Convert.ToString(dr["destino"]),
                         nome_viagem = Convert.ToString(dr["nome_viagem"]),
                         descricao = Convert.ToString(dr["descricao"]),
                         dt_chegada = Convert.ToString(dr["dt_chegada"]),
                         dt_ida = Convert.ToString(dr["dt_ida"]),
                         cd_viagem = Convert.ToString(dr["cd_viagem"]),
                         vl_total = Convert.ToString(dr["vl_total"]),
                         img_viagem = Convert.ToString(dr["img_viagem"]),
                      

                     });
            }
            return ViList;
        }


        //ATUALIZAR VIAGEM
        public bool atualizarViagem(Viagem viag)
        {

            MySqlCommand cmd = new MySqlCommand("update Viagem set nome_viagem=@nm tipo_transporte=@tipo_transporte,origem=@origem,destino=@destino,dt_ida=@dt_ida,dt_chegada=@dt_chegada,duracao=@duracao,descricao=@descricao,vl_total@vl_total,img_viagem=@img_viagem  where cd_viagem=@viagem,", con.MyConectarBD());

            cmd.Parameters.Add("@viagem", MySqlDbType.VarChar).Value = viag.cd_viagem;

            cmd.Parameters.Add("@nm", MySqlDbType.VarChar).Value = viag.nome_viagem;

            cmd.Parameters.Add("@tipo_transporte", MySqlDbType.VarChar).Value = viag.tipo_transporte;

            cmd.Parameters.Add("@origem", MySqlDbType.VarChar).Value = viag.origem;

            cmd.Parameters.Add("@destino", MySqlDbType.VarChar).Value = viag.destino;

            cmd.Parameters.Add("@dt_ida", MySqlDbType.VarChar).Value = viag.dt_ida;

            cmd.Parameters.Add("@dt_chegada", MySqlDbType.VarChar).Value = viag.dt_chegada;

      

            cmd.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = viag.descricao;

            cmd.Parameters.Add("@vl_total", MySqlDbType.VarChar).Value = viag.vl_total;

            cmd.Parameters.Add("@img_viagem", MySqlDbType.VarChar).Value = viag.img_viagem;


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }

        //EXCLUIR VIAGEM
        public bool excluirViagem(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Viagem where cd_viagem = @cd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<Viagem> ListarViagemValor(Viagem viagem )
        {
            List<Viagem> ViList = new List<Viagem>();
            MySqlCommand cmd = new MySqlCommand("select * from Viagem where cd_viagem = @cd", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = viagem.cd_viagem;


            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();
            con.MyDesconectarBD();

            sd.Fill(dt);

            if (leitor.HasRows)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    ViList.Add(

                         new Viagem
                         {
                             cd_viagem = Convert.ToString(dr["cd_viagem"]),

                             nome_viagem  = Convert.ToString(dr["nome_viagem"]),

                             vl_total = Convert.ToString(dr["vl_total"])


                         });

                    valor = Convert.ToString(dr["vl_total"]);
                }
                return ViList;
            }
            else
            {
                valor = null;
                return ViList;
            }


        }

    }
}