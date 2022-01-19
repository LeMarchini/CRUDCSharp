using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUD
{
    class connection
    {
        public static void conAndCom(MySqlCommand comando)
        {
            string connString = @"server=localhost;database=clients;uid=root;Pwd=root;persistsecurityinfo=True";
            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = conn.CreateCommand();
            MySqlDataReader reader = null;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = comando.CommandText;
            conn.Open();

            try
            {
                if (menu.choice == 1)
                {
                    cmd.Parameters.Add("?username", MySqlDbType.VarChar).Value = insert.userName;
                    cmd.Parameters.Add("?userEmail", MySqlDbType.VarChar).Value = insert.userEmail;
                    cmd.ExecuteNonQuery();
                    long id = cmd.LastInsertedId;
                    Console.WriteLine();
                    Console.WriteLine("Usuario Inserido com sucesso no ID: " + id);
                    Console.WriteLine("Aperte qualquer tecla para voltar ao Menu.");
                    Console.ReadKey();
                }
                else if (menu.choice == 2)
                {
                    try
                    {
                        cmd.Parameters.Add("?username", MySqlDbType.VarChar).Value = edit.userName;
                        cmd.Parameters.Add("?userEmail", MySqlDbType.VarChar).Value = edit.userEmail;
                        cmd.Parameters.Add("?clientid", MySqlDbType.Int32).Value = edit.id;
                        cmd.ExecuteNonQuery();

                    }
                    catch (MySqlException e)
                    {
                        Console.WriteLine("ERRO: " + e);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Usuario alterado com sucesso!");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao Menu.");
                    Console.ReadKey();
                }
                else if (menu.choice == 3)
                {
                    cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = search.id;
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var column1 = reader["clientid"];
                        var column2 = reader["username"];
                        var column3 = reader["useremail"];
                        Console.Clear();
                        Console.WriteLine("Informações do Cliente:");
                        Console.WriteLine("ID do Cliente: " + column1);
                        Console.WriteLine("Nome do Cliente: " + column2);
                        Console.WriteLine("Email do Cliente: " + column3);
                    }
                    Console.WriteLine("Aperte qualquer tecla para voltar ao Menu.");
                    Console.ReadKey();
                }
                else if (menu.choice == 4)
                {
                    cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = delete.id;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine();
                    Console.WriteLine("Usuario com ID " + delete.id + " Foi deletado com sucesso!");
                    Console.WriteLine("Aperte qualquer tecla para voltar ao Menu.");
                    Console.ReadKey();
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
