using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Ecommerce.Models;
using MySql.Data.MySqlClient;

namespace Ecommerce.Acoes
{
    public class AcoesCliente
    {

        conexao con = new conexao();
        public static int VerificaCliente;
        public void VerificaUsuarioLogin(Usuario user)
        {
            
            MySqlCommand cmd = new MySqlCommand("Select * from Cliente  where CPF = @cpf and senha = @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.cpf;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                VerificaCliente = 1;
                while (leitor.Read())
                {
                    user.cpf = Convert.ToString(leitor["CPF"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                    user.nome = Convert.ToString(leitor["nome"]);
                    user.telefone = Convert.ToString(leitor["telefone"]);
                    user.email = Convert.ToString(leitor["email"]);
                    user.rg = Convert.ToString(leitor["rg"]);
                    user.img = Convert.ToString(leitor["img"]);


                }
            }
            else
            {
                VerificaCliente = 0;
                user.cpf = null;
                user.senha = null;
                user.tipo = null;
                user.nome = null;
                user.telefone = null;
                user.email = null;
                user.rg = null;
                user.img = null;


            }

        }
        public void inserirCliente(Cliente cliente)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO Cliente(nome,telefone,email,CPF,rg,senha,img,tipo) VALUES (@nm,@tel,@email,@CPF,@rg,@senha,@img,3)", con.MyConectarBD());

            cmd.Parameters.Add("@nm", MySqlDbType.VarChar).Value = cliente.nome;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = cliente.telefone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.email;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = cliente.rg;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cliente.senha;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = cliente.img;
            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }

        public void inserirClienteFuncionario(Cliente cliente)
        {

            MySqlCommand cmd = new MySqlCommand("START TRANSACTION; INSERT INTO Cliente(nome, senha, CPF, tipo, telefone, email, rg, img)VALUES(@nm,@senha,@CPF, 4,@tel,@email,@rg,@img);" +
                "UPDATE Funcionario SET tipo = 4  WHERE CPF = @CPF; COMMIT; ", con.MyConectarBD());

            cmd.Parameters.Add("@nm", MySqlDbType.VarChar).Value = cliente.nome;
            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = cliente.telefone;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.email;
            cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = cliente.rg;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cliente.senha;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = cliente.img;
            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }


        public List<Cliente> ListarCliente()
        {
            List<Cliente> CliList = new List<Cliente>();

            MySqlCommand cmd = new MySqlCommand("select * from Cliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                CliList.Add(

                     new Cliente
                     {
                         CPF = Convert.ToString(dr["CPF"]),
                         nome = Convert.ToString(dr["nome"]),
                         email = Convert.ToString(dr["email"]),
                         telefone = Convert.ToString(dr["telefone"]),
                         rg = Convert.ToString(dr["rg"]),
                         senha  = Convert.ToString(dr["senha"]),
                         img = Convert.ToString(dr["img"])

                     });
            }
            return CliList;
        }


        public bool atualizarCliente(Cliente cli)
        {

            MySqlCommand cmd = new MySqlCommand("update Cliente set nome=@nome,rg=@rg,email=@email,tel=@tel,senha=@senha, img=@img  where CPF=@cliente,", con.MyConectarBD());



            cmd.Parameters.Add("@cliente", MySqlDbType.VarChar).Value = cli.CPF;

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cli.nome;

            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = cli.rg;

            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cli.email;

            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = cli.telefone;

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cli.senha;

            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = cli.img;


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }

        public bool excluirCliente(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Cliente where CPF = @CPF", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@CPF", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<Cliente> GetDetalhesCliente()
        {
            List<Cliente> Clientelist = new List<Cliente>();

            MySqlCommand cmd = new MySqlCommand("select * from Cliente", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Clientelist.Add(
                      new Cliente
                      {
                          CPF = Convert.ToString(dr["CPF"]),
                          nome = Convert.ToString(dr["nome"]),
                          email = Convert.ToString(dr["email"]),
                          telefone = Convert.ToString(dr["telefone"]),
                          rg = Convert.ToString(dr["rg"]),
                          img = Convert.ToString(dr["img"])

                      });
            }
            return Clientelist;
        }

    }
}