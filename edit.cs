using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class edit
    {
        public static string userName, userEmail;
        public static int id;
        public static MySqlCommand cmd = new MySqlCommand();
        public static int lastid = menu.getLastID();
        public static MySqlCommand editUser()
        {
            Console.WriteLine("Digite o ID do usuario a ser alterado:");
            id = int.Parse(Console.ReadLine());

            if (lastid < id)
            {
                Console.Clear();
                Console.WriteLine("ERRO! O Numero informado não está registrado.");
                Console.WriteLine();
                editUser();
            }
            else
            {
                Console.WriteLine("Insira o novo nome do usuario:");
                userName = Console.ReadLine();

                Console.WriteLine("Insira o novo email do Usuario:");
                userEmail = Console.ReadLine();

                cmd.CommandText = "update clientlist set username = ?username, userEmail = ?useremail where clientid = ?clientid";
            }
            return cmd;
        }
    }
}
