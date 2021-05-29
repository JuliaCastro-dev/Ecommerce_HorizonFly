using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesLogin
    {

        
        conexao con = new conexao();
    

        public void TestarUsuario(Usuario user)
        {
            MySqlCommand cmd = new MySqlCommand("call Login(@cpf, @senha)", con.MyConectarBD());
           
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.cpf;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.cpf = Convert.ToString(leitor["CPF"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                    user.nome = Convert.ToString(leitor["nome"]);
                    user.telefone = Convert.ToString(leitor["telefone"]);
                    user.email = Convert.ToString(leitor["email"]);
                    user.rg= Convert.ToString(leitor["rg"]);
                    user.img = Convert.ToString(leitor["img"]);
                   

                }
            }
            else
            {
                user.cpf = null;
                user.senha = null;
                user.tipo = null;
                user.nome = null;
                user.telefone = null;
                user.email= null;
                user.rg= null;
                user.img = null;


            }

            con.MyDesconectarBD();
        }

        public static int VerificaSenhaUsu;
        public List<Usuario> VerificaSenha(Funcionario func)// verifica se existe um funcionário para mudar  senha
        {
            List<Usuario> VUA = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario where CPF = @cpf ", con.MyConectarBD());

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = func.CPF;

            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();
            con.MyDesconectarBD();

            sd.Fill(dt);

            if (leitor.HasRows)
            {
                VerificaSenhaUsu = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    VUA.Add(

                           new Usuario
                           {

                               cpf = Convert.ToString(dr["CPF"])
                              

                           });
                }
                return VUA;
            }
            else
            {
                VerificaSenhaUsu = 0;
                
                return VUA;
            }


        }


        public void AlterarSenhaCliente(Usuario cli)

        {

            MySqlCommand cmd = new MySqlCommand("UPDATE Cliente SET senha = @senha WHERE CPF = @usuario ", con.MyConectarBD());



            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cli.cpf;

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cli.senha;

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }


        public void AlterarSenhaFuncionario(Usuario func)

        {

            MySqlCommand cmd = new MySqlCommand("UPDATE Funcionario SET senha = @senha WHERE CPF = @usuario ", con.MyConectarBD());



            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = func.cpf;

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = func.senha;

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }

    }
}