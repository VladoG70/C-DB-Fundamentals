using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ChangeTownNames
    {
    class ChangeTownNamesToUpperCase
        {
        static void Main(string[] args)
            {
            string queryGetTownNames = File.ReadAllText(@"..\..\SQLQuery-ChangeTownNamesInCountry.sql");

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Database = MinionsDB;
                                                        Integrated Security = true;");
            connection.Open();
            using (connection)
                {
                Console.Write("Enter country name: ");
                string countryName = Console.ReadLine();
                SqlCommand cmdGetTownNamesByCountry = new SqlCommand(queryGetTownNames, connection);
                SqlParameter paramCountryName = new SqlParameter("@countryName", countryName);
                cmdGetTownNamesByCountry.Parameters.Add(paramCountryName);

                SqlDataReader readTowns = cmdGetTownNamesByCountry.ExecuteReader();

                int index = 0;
                List<string> townNames = new List<string>();
                while (readTowns.Read())
                    {
                    townNames.Add((string)readTowns[0]);
                    index++;
                    }
                if (index == 0)
                    {
                    Console.WriteLine("No town names were affected.");
                    }
                else
                    {
                    Console.WriteLine($"{index} town names were affected.");
                    Console.WriteLine("[" + String.Join(", ", townNames) + "]");
                    }
                }
            }
        }
    }
