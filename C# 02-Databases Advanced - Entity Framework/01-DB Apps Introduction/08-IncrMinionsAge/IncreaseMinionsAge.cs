using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_IncrMinionsAge
    {
    class IncreaseMinionsAge
        {
        static void Main(string[] args)
            {
            string queryGetMinions = File.ReadAllText(@"..\..\SQLQuery-GetMinions.sql");
            string queryUpdateMinionsAge = File.ReadAllText(@"..\..\SQLQuery-UpdateMinionsAge.sql");


            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Database = MinionsDB;
                                                        Integrated Security = true;");

            Console.Write("Enter Minions IDs (separated by space): ");
            int[] arrID = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            connection.Open();
            using (connection)
                {
                for (int i = 0; i < arrID.Length; i++)
                    {
                    SqlCommand cmdUpdate = new SqlCommand(queryUpdateMinionsAge, connection);
                    SqlParameter paramID = new SqlParameter("@minionsID", arrID[i]);
                    cmdUpdate.Parameters.Add(paramID);
                    cmdUpdate.ExecuteNonQuery();
                    }

                SqlCommand cmdGetMinions = new SqlCommand(queryGetMinions, connection);
                SqlDataReader readerMinions = cmdGetMinions.ExecuteReader();

                while (readerMinions.Read())
                    {
                    Console.WriteLine($"{readerMinions[0]} {readerMinions[1]}");
                    }
                }
            }
        }
    }
