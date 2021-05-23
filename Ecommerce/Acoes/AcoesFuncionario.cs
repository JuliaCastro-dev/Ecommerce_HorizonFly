using Ecommerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ecommerce.Acoes
{
    public class AcoesFuncionario
    {
        conexao con = new conexao();

        // Verifica usuario para ver se o cliente a ser cadastrado é um funcionário
        public void VerificaUsuario(Cliente user)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario where CPF = @cpf and senha - @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.CPF;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.CPF = Convert.ToString(leitor["CPF"]);
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
                user.CPF = null;
                user.senha = null;
                user.tipo = null;
                user.nome = null;
                user.telefone = null;
                user.email = null;
                user.rg = null;
                user.img = null;


            }

            con.MyDesconectarBD();
        }

        public void inserirFuncionario(Funcionario func)

        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO Funcionario (nome,senha,CPF,cargo,tipo,telefone,email,rg,img)" +
                " VALUES (@nome,@senha,@cpf,@cargo,2,@tel,@email,@rg,@img);", con.MyConectarBD());



            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = func.nome;

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = func.senha;

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = func.CPF;

            cmd.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = func.cargo_func;

            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = func.telefone;

            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = func.email;

            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = func.rg;

            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = func.img;

            cmd.ExecuteNonQuery();

            con.MyDesconectarBD();

        }
        public List<Funcionario> ListarFuncionario()
        {
            List<Funcionario> FuncList = new List<Funcionario>();
            MySqlCommand cmd = new MySqlCommand("select * from Funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                FuncList.Add(

                    new Funcionario
                    {
                        CPF = Convert.ToString(dr["CPF"]),
                        nome = Convert.ToString(dr["nome"]),
                        email = Convert.ToString(dr["email"]),
                        telefone = Convert.ToString(dr["telefone"]),
                        rg = Convert.ToString(dr["rg"]),
                        cargo_func = Convert.ToString(dr["cargo"]),
                        senha = Convert.ToString(dr["senha"]),
                        img = Convert.ToString(dr["img"])


                    });
            }
            return FuncList;
        }

        public bool atualizarFuncionario(Funcionario func)
        {

            MySqlCommand cmd = new MySqlCommand("update Funcionario set nome=@nome,rg=@rg,@cargo=cargo,email=@email,tel=@tel,senha=@senha, img=@img  where CPF=@funcionario,", con.MyConectarBD());



            cmd.Parameters.Add("@cliente", MySqlDbType.VarChar).Value = func.CPF;

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = func.nome;

            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = func.rg;

            cmd.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = func.cargo_func;

            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = func.email;

            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = func.telefone;

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = func.senha;

            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = func.img;


            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }

        public bool excluirFuncionario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Funcionario where CPF = @CPF", con.MyConectarBD());

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