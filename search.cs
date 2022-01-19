using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class search
    {
        public static int id;
        public static MySqlCommand cmd = new MySqlCommand();
        public static MySqlCommand searchClient()
        {
            Console.Clear();
            Console.WriteLine("Digite o ID do usuario a ser buscado:");
            id = int.Parse(Console.ReadLine());
            cmd.CommandText = "SELECT * FROM clientlist where clientid = ?id";

            return cmd;
        }
    }
}
