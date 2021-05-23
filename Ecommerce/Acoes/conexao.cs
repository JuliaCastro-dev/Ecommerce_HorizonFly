using MySql.Data.MySqlClient;
using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class conexao
{

        MySqlConnection cn = new MySqlConnection("Server=localhost;DataBase=db_horizon;User=root;pwd=scorpia");
        public static string msg;

        public MySqlConnection MyConectarBD()
        {

            try
            {
                cn.Open();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }

        public MySqlConnection MyDesconectarBD()
        {

            try
            {
                cn.Close();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    

}
