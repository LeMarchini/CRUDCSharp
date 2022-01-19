using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUD
{
    class insert
    {
        public static string userName, userEmail;
        public static MySqlCommand insertUser()
        {
            MySqlCommand cmd = new MySqlCommand();

            Console.WriteLine("Insira o nome do usuario:");
            userName = Console.ReadLine();

            Console.WriteLine("Insira o email do Usuario:");
            userEmail = Console.ReadLine();

            cmd.CommandText = "INSERT INTO clientlist(username,userEmail) VALUES (?userName,?userEmail)";

            return cmd;
        }
    }
}
