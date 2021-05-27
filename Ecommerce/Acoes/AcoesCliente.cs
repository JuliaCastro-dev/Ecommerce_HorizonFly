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

            MySqlCommand cmd = new MySqlCommand("START TRANSACTION; INTO CLiente(nome, senha, CPF, tipo, telefone, email, rg, img)" +
                "VALUES(@nm,@senha,@CPF, '4',@tel,@email,@rg,@img);" +
                "UPDATE Funcionario SET tipo = '4'  WHERE CPF = @CPF;COMMIT; ", con.MyConectarBD());

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

    }
}