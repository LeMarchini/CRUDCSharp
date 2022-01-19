using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUD
{
    class menu
    {
        public static int choice;
        static void Main(string[] args)
        {
            MySqlCommand cmd = new MySqlCommand();

            while (choice <= 4)
            {
                Console.Clear();
                Console.WriteLine("Selecione o que deseja fazer:");
                Console.WriteLine("1 - Inserir Usuario");
                Console.WriteLine("2 - Editar Usuario");
                Console.WriteLine("3 - Procurar Usuario");
                Console.WriteLine("4 - Deletar Usuario");
                Console.WriteLine("5 - Sair");
                ConsoleKeyInfo UserInput = Console.ReadKey();
                choice = int.Parse(UserInput.KeyChar.ToString());
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        cmd = insert.insertUser();
                        connection.conAndCom(cmd);
                        break;
                    case 2:
                        Console.Clear();
                        cmd = edit.editUser();
                        connection.conAndCom(cmd);
                        break;
                    case 3:
                        Console.Clear();
                        cmd = search.searchClient();
                        connection.conAndCom(cmd);
                        break;
                    case 4:
                        Console.Clear();
                        cmd = delete.deleteUser();
                        connection.conAndCom(cmd);
                        break;
                }
            }
        }

        public static int getLastID()
        {
            int lastid = 0;
            try
            {
                MySqlDataReader reader = null;
                string connString = @"server=localhost;database=clients;uid=root;Pwd=root;persistsecurityinfo=True";
                string selectCmd = "SELECT max(clientid) FROM clientlist";
                MySqlConnection conn = new MySqlConnection(connString);

                MySqlCommand command = new MySqlCommand(selectCmd, conn);
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var ColumnName = reader["max(clientid)"];
                    lastid = int.Parse(ColumnName.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lastid;
        }
    }
}
