using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_PrintAllMinionN
    {
    class PrintAllMinionNames
        {
        static void Main(string[] args)
            {
            List<string> minionNames = new List<string>();
            string queryGetMinionNames = File.ReadAllText(@"..\..\SQLQuery-GetMinionNames.sql");

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Database = MinionsDB;
                                                        Integrated Security = true;");
            connection.Open();
            using (connection)
                {
                SqlCommand cmd = new SqlCommand(queryGetMinionNames, connection);
                SqlDataReader readerNames = cmd.ExecuteReader();
                while (readerNames.Read())
                    {
                    minionNames.Add((string)readerNames[0]);
                    }
                }
            int lenList = minionNames.Count - 1;
            for (int i = 0; i <= lenList / 2; i++)
                {
                Console.WriteLine(minionNames[i]);
                if (i != (lenList - i))
                    {
                    Console.WriteLine(minionNames[lenList - i]);
                    }
                }
            }
        }
    }
