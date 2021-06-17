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

            MySqlCommand cmd = new MySqlCommand("update Viagem set nome_viagem = @nm, cd_tipotransporte = @tipo,origem = @origem , destino = @destino, dt_ida = @dt_ida, dt_chegada = @dt_chegada,descricao = @descricao,vl_total = @vl_total, img_viagem = @img_viagem  where cd_viagem = @viagem", con.MyConectarBD());

            cmd.Parameters.Add("@viagem", MySqlDbType.VarChar).Value = viag.cd_viagem;

            cmd.Parameters.Add("@nm", MySqlDbType.VarChar).Value = viag.nome_viagem;

            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = viag.tipo_transporte;

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

        public void VerificaValor( Viagem viagem)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Viagem where cd_viagem = @cd", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = viagem.cd_viagem;
          

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
               
                while (leitor.Read())
                {
                   viagem.cd_viagem = Convert.ToString(leitor["cd_viagem"]);
                   viagem.nome_viagem = Convert.ToString(leitor["nome_viagem"]);
                   viagem.vl_total = Convert.ToString(leitor["vl_total"]);


                }
            }
            else
            {
                viagem.cd_viagem = null;
                viagem.nome_viagem = null;
                viagem.vl_total = null;


            }

        }


        public List<Viagem> GetDetalhesViagem()
        {
            List<Viagem> Vilist = new List<Viagem>();

            MySqlCommand cmd = new MySqlCommand("  select * from vw_mostraviagem", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
     
            DataTable dt = new DataTable();


            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows )
            {
                Vilist.Add(
                      new Viagem
                      {
                          cd_viagem = Convert.ToString(dr["cd_viagem"]),
                          nome_viagem = Convert.ToString(dr["nome_viagem"]),
                          origem = Convert.ToString(dr["CidadeOrigem"]),
                          dt_chegada = Convert.ToString(dr["dt_chegada"]),
                          dt_ida = Convert.ToString(dr["dt_ida"]),
                          destino = Convert.ToString(dr["CidadeDestino"]),
                          vl_total = Convert.ToString(dr["vl_total"]),
                          descricao = Convert.ToString(dr["descricao"]),
                          img_viagem = Convert.ToString(dr["img_viagem"]),
                          tipo_transporte = Convert.ToString(dr["tipo_transporte"])


                      });
            }
            return Vilist;
        }
      

        public void PegaDados(Viagem viagem)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Viagem where cd_viagem = @cd", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = viagem.cd_viagem;


            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {

                while (leitor.Read())
                {
                    viagem.cd_viagem = Convert.ToString(leitor["cd_viagem"]);
                    viagem.nome_viagem = Convert.ToString(leitor["nome_viagem"]);
                    viagem.dt_ida = Convert.ToString(leitor["dt_ida"]);
                    viagem.dt_chegada = Convert.ToString(leitor["dt_chegada"]);
                    viagem.destino = Convert.ToString(leitor["destino"]);
                    viagem.origem = Convert.ToString(leitor["origem"]);
                    viagem.tipo_transporte = Convert.ToString(leitor["cd_tipotransporte"]);
                    viagem.img_viagem = Convert.ToString(leitor["img_viagem"]);
                    viagem.vl_total = Convert.ToString(leitor["vl_total"]);


                }
            }
            else
            {
                viagem.nome_viagem = null;
                viagem.dt_ida = null;
                viagem.dt_chegada= null;
                viagem.destino = null;
                viagem.origem = null;
                viagem.tipo_transporte = null;

            }

        }
    }
}