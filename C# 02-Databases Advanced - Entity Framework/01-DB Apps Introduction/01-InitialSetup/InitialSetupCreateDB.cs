using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_InitialSetup
    {
    class InitialSetupCreateDB
        {
        static void Main(string[] args)
            {
            int affectedRows = 0;

            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Integrated Security = true;");
            // CREATE DB
            connection.Open();
            string sqlCreateDB = "CREATE DATABASE MinionsDB";
            SqlCommand createDBCommand = new SqlCommand(sqlCreateDB, connection);
            using (connection)
                {
                affectedRows = createDBCommand.ExecuteNonQuery();
                Console.WriteLine($"DATABASE MinionsDB Created! - {affectedRows} rows affected");
                }

            }
        }
    }
