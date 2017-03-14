using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_GetMinionNames
    {
    class GetMinionNames
        {
        static void Main(string[] args)
            {
            string queryFindVillainNameById = File.ReadAllText(@"..\..\SQLQuery-VillainNameByID.sql");
            string queryGetMinionNames = File.ReadAllText(@"..\..\SQLQuery-GetMinionNames.sql");

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Database = MinionsDB;
                                                        Integrated Security = true;");

            connection.Open();
            using (connection)
                {
                int villainId = int.Parse(Console.ReadLine());
                SqlCommand cmdFindVillainNameById = new SqlCommand(queryFindVillainNameById, connection);
                SqlParameter villainIdParam = new SqlParameter("@villainId", villainId);
                cmdFindVillainNameById.Parameters.Add(villainIdParam);

                SqlDataReader reader = cmdFindVillainNameById.ExecuteReader();

                if (reader.Read())
                    {
                    string villName = (string)reader["Name"]; // or reader[1]
                    Console.WriteLine($"Villain: {villName}");

                    SqlCommand cmdGetMinionNames = new SqlCommand(queryGetMinionNames, connection);
                    SqlParameter villainIdParam1 = new SqlParameter("@villainId", villainId);
                    cmdGetMinionNames.Parameters.Add(villainIdParam1);

                    reader.Close(); // NE MOJE 2 DataReader-a edin v drug! Triabva predishnia da se zatvori!!
                    SqlDataReader readerMinions = cmdGetMinionNames.ExecuteReader();
                    int index = 1;
                    if (!readerMinions.Read())
                        {
                        Console.WriteLine("(no minions)");
                        }
                    else
                        {
                        while (readerMinions.Read())
                            {
                            Console.WriteLine($"{index}. {readerMinions[1]} {readerMinions[2]}");
                            index++;
                            }
                        }
                    }
                else
                    {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    }

                }
            }
        }
    }
