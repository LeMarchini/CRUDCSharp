using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class delete
    {
        public static int id;
        public static MySqlCommand deleteUser()
        {
            MySqlCommand cmd = new MySqlCommand();

            Console.WriteLine("Insira o ID do usuario a ser deletado:");
            id = int.Parse(Console.ReadLine());

            cmd.CommandText = "delete from clientlist where clientid = ?id";

            return cmd;
        }
    }
}
