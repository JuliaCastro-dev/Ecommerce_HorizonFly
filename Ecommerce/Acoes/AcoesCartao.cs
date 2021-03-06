using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesCartao
    {

        conexao con = new conexao();

        public void inserirCartao (Cartao card)

        {

            MySqlCommand cmd = new MySqlCommand("insert into Cartao(CPF, nome_cartao , nome_impresso, numero_cartao, cvv_cartao , validade_cartao)values(@cpf, @nome, @nmImpresso , @num, @cvv, @val)", con.MyConectarBD());


            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = card.nm_cartao;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = card.cpf;
            cmd.Parameters.Add("@nmImpresso", MySqlDbType.VarChar).Value = card.nm_impresso;
            cmd.Parameters.Add("@num", MySqlDbType.VarChar).Value = card.num_cartao;
            cmd.Parameters.Add("@cvv", MySqlDbType.VarChar).Value = card.cvv_cartao;
            cmd.Parameters.Add("@val", MySqlDbType.VarChar).Value = card.validade;


            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }
        public List<Cartao> ListarCartao()
        {
            List<Cartao> CarList = new List<Cartao>();

            MySqlCommand cmd = new MySqlCommand("select * from Cartao", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                CarList.Add(

                     new Cartao
                     {
                         cd_cartao = Convert.ToString(dr["cd_cartao"]),
                         cpf = Convert.ToString(dr["CPF"]),
                         nm_cartao = Convert.ToString(dr["nome_cartao"]),
                         nm_impresso = Convert.ToString(dr["nome_impresso"]),
                         num_cartao = Convert.ToString(dr["numero_cartao"]),
                         cvv_cartao = Convert.ToString(dr["cvv_cartao"]),
                         validade = Convert.ToString(dr["validade_cartao"])


                     });
            }
            return CarList;
        }

        public void PegaDados(Cartao card)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Cartao where cd_cartao = @cd", con.MyConectarBD());

            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = card.cd_cartao;


            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {

                while (leitor.Read())
                {
                    card.cd_cartao = Convert.ToString(leitor["cd_cartao"]);
                    card.cpf = Convert.ToString(leitor["CPF"]);
                    card.nm_cartao = Convert.ToString(leitor["nome_cartao"]);
                    card.nm_impresso = Convert.ToString(leitor["nome_impresso"]);
                    card.num_cartao = Convert.ToString(leitor["numero_cartao"]);
                    card.cvv_cartao = Convert.ToString(leitor["cvv_cartao"]);
                    card.validade = Convert.ToString(leitor["validade_cartao"]);

                }
            }
            else
            {
                card.cd_cartao = null;
                card.nm_cartao = null;
                card.nm_impresso = null;
                card.num_cartao = null;
                card.cvv_cartao = null;
                card.validade = null;


            }

        }

        public bool atualizarCartao(Cartao cart)
        {

            MySqlCommand cmd = new MySqlCommand("update Cartao set nome_cartao=@nome_cartao,nome_impresso=@nome_impresso,numero_cartao=@numero_cartao,cvv_cartao=@cvv_cartao,validade_cartao=@validade_cartao where cd_cartao=@cartao", con.MyConectarBD());

            cmd.Parameters.Add("@cartao", MySqlDbType.VarChar).Value = cart.cd_cartao;

            cmd.Parameters.Add("@nome_cartao", MySqlDbType.VarChar).Value = cart.nm_cartao;

            cmd.Parameters.Add("@nome_impresso", MySqlDbType.VarChar).Value = cart.nm_impresso;

            cmd.Parameters.Add("@numero_cartao", MySqlDbType.VarChar).Value = cart.num_cartao;

            cmd.Parameters.Add("@cvv_cartao", MySqlDbType.VarChar).Value = cart.cvv_cartao;

            cmd.Parameters.Add("@validade_cartao", MySqlDbType.VarChar).Value = cart.validade;


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }

        public bool excluirCartao(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Cartao where cd_cartao = @cd", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@cd", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Cartao> GetDetalhesCartao()
        {
            List<Cartao> Cartaolist = new List<Cartao>();

            MySqlCommand cmd = new MySqlCommand("select * from Cartoes", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                string card1 = dr["numero_cartao"].ToString().Insert(4, " ");
                string card2 = card1.Insert(9, " ");
                string card3 = card2.Insert(14, " ");
                string val1 = dr["validade_cartao"].ToString().Remove(0, 3);
                string val2 = val1.Remove(8, 8);

                Cartaolist.Add(
                      new Cartao
                      {
                          cd_cartao = Convert.ToString(dr["cd_cartao"]),
                          cpf = Convert.ToString(dr["CPF"]),
                          rg = Convert.ToString(dr["rg"]),
                          cvv_cartao = Convert.ToString(dr["cvv_cartao"]),
                          num_cartao = card3.ToString(),
                          nm_impresso = Convert.ToString(dr["nome_impresso"]),
                          nm_cartao = Convert.ToString(dr["nome_cartao"]),
                          validade = val2.ToString()

                      }); 
            }
            return Cartaolist;
        }

        public List<Cartao> GetCartoes(Cartao card)
        {
            List<Cartao> Cartaolist = new List<Cartao>();

            MySqlCommand cmd = new MySqlCommand("select * from Cartoes where CPF = @cpf", con.MyConectarBD());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = card.cpf;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {

                string card1 = dr["numero_cartao"].ToString().Insert(4, " ");
                string card2 = card1.Insert(9, " ");
                string card3 = card2.Insert(14, " ");
                string val1 = dr["validade_cartao"].ToString().Remove(0, 3);
                string val2 = val1.Remove(8, 8);
                Cartaolist.Add(
                      new Cartao
                      {
                        
                          rg = Convert.ToString(dr["rg"]),
                          cd_cartao = Convert.ToString(dr["cd_cartao"]),
                          cpf = Convert.ToString(dr["CPF"]),
                          cvv_cartao = Convert.ToString(dr["cvv_cartao"]),
                          num_cartao = card3.ToString(),
                          nm_impresso = Convert.ToString(dr["nome_impresso"]),
                          nm_cartao = Convert.ToString(dr["nome_cartao"]),
                          validade = val2.ToString()

                      });
            }
            return Cartaolist;
        }
    }
}