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
        public static int Verifica;
        public static int VerificaFuncionario;

        // Verifica usuario para ver se o cliente a ser cadastrado é um funcionário
        public List<Usuario> VerificaUsuarioCadastroCliente(Usuario user)
        {
            List<Usuario> VUL = new List<Usuario>();
            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario where CPF = @cpf", con.MyConectarBD());

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.cpf;
           

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

                    VUL.Add(

                           new Usuario
                           {

                               cpf = Convert.ToString(dr["CPF"]),
                               nome = Convert.ToString(dr["nome"]),
                               email = Convert.ToString(dr["email"]),
                               telefone = Convert.ToString(dr["telefone"]),
                               rg = Convert.ToString(dr["rg"]),
                               senha = Convert.ToString(dr["senha"]),
                               img = Convert.ToString(dr["img"])

                           });
                }
                return VUL;
            }
            else
            {
                Verifica = 0;
                user.cpf = null;
                return VUL;
            }
            

        }


        public void VerificaLogin(Usuario user)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario where CPF = @cpf and senha = @Senha", con.MyConectarBD());

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.cpf;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.senha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                VerificaFuncionario= 1;
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
                VerificaFuncionario = 0;

            }

        }


        public void VerificafUNC(Usuario user)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario where CPF = @cpf ", con.MyConectarBD());

            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.cpf;
           

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
                    user.rg = Convert.ToString(leitor["rg"]);
                    user.img = Convert.ToString(leitor["img"]);


                }
            }
            else
            {
                user.cpf = null;

            }

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

        public void atualizarFuncionario(Funcionario func)
        {

            MySqlCommand cmd = new MySqlCommand("update Funcionario set nome = @nome, rg = @rg, cargo = @cargo, email = @email, telefone = @tel,senha = @senha, tipo = @tipo, img = @img where CPF = @funcionario", con.MyConectarBD());



            cmd.Parameters.Add("@funcionario", MySqlDbType.VarChar).Value = func.CPF;

            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = func.nome;

            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = func.rg;

            cmd.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = func.cargo_func;

            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = func.email;

            cmd.Parameters.Add("@tel", MySqlDbType.VarChar).Value = func.telefone;

            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = func.senha;

            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = func.img;

            cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = func.tipo;

            cmd.ExecuteNonQuery();
        
            con.MyDesconectarBD();

            

        }

        public bool excluirFuncionario(int id)
        {
            MySqlCommand cmd = new MySqlCommand("delete from Funcionario where rg = @rg", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@rg", id);

            int i = cmd.ExecuteNonQuery();
            con.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public void PegaDados(Funcionario func)
        {

            MySqlCommand cmd = new MySqlCommand("Select * from Funcionario where rg = @rg", con.MyConectarBD());

            cmd.Parameters.Add("@rg", MySqlDbType.VarChar).Value = func.rg;


            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {

                while (leitor.Read())
                {
                    func.rg = Convert.ToString(leitor["rg"]);
                    func.CPF = Convert.ToString(leitor["CPF"]);
                    func.nome = Convert.ToString(leitor["nome"]);
                    func.cargo_func = Convert.ToString(leitor["cargo"]);
                    func.telefone = Convert.ToString(leitor["telefone"]);
                    func.email = Convert.ToString(leitor["email"]);
                    func.img = Convert.ToString(leitor["img"]);
                    func.tipo = Convert.ToString(leitor["tipo"]);

                }
            }
            else
            {
                func.rg = null;
                func.CPF = null;
                func.nome = null;
                func.cargo_func = null;
                func.telefone = null;
                func.email = null;
                func.tipo = null;

                func.img = null;


            }

        }


        public List<Funcionario> GetDetalhesFuncionario()
        {
            List<Funcionario> Funclist = new List<Funcionario>();

            MySqlCommand cmd = new MySqlCommand("select * from Funcionario", con.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Funclist.Add(
                      new Funcionario
                      {
                          CPF = Convert.ToString(dr["CPF"]),
                          nome = Convert.ToString(dr["nome"]),
                          cargo_func = Convert.ToString(dr["cargo"]),
                          email = Convert.ToString(dr["email"]),
                          telefone = Convert.ToString(dr["telefone"]),
                          rg = Convert.ToString(dr["rg"]),
                          img = Convert.ToString(dr["img"])

                      });
            }
            return Funclist;
        }
    }
}