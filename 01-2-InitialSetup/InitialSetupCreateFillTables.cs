using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_2_InitialSetup
    {
    class InitialSetupCreateFillTables
        {
        static void Main(string[] args)
            {
            int affectedRows = 0;
            string queryCreateFillTables = File.ReadAllText(@"..\..\SQLQuery-01-InitialSetup.sql");

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Integrated Security = true;");

            // CREATE & FILL Tables
            connection.Open();
            SqlCommand createFillTables = new SqlCommand(queryCreateFillTables, connection);
            using (connection)
                {
                affectedRows = createFillTables.ExecuteNonQuery();
                Console.WriteLine($"TABLES Cerated & Fills - {affectedRows} rows affected");
                }
            }
        }
    }
