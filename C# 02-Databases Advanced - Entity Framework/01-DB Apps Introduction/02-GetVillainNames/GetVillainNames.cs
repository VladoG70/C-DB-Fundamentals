using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GetVillainNames
    {
    class GetVillainNames
        {
        static void Main(string[] args)
            {
            string query = File.ReadAllText(@"..\..\SQLQuery-GetVillainsNames.sql");

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Database = MinionsDB;
                                                        Integrated Security = true;");

            // SELECT
            connection.Open();
            SqlCommand selectVillainsName = new SqlCommand(query, connection);
            using (connection)
                {
                SqlDataReader row = selectVillainsName.ExecuteReader();

                while (row.Read())
                    {
                    Console.WriteLine($"{row[0]} {row[1]}");
                    }
                }
            }
        }
    }
