using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_IncAgeStoredPro
    {
    class IncreaseAgeStoredProcedure
        {
        static void Main(string[] args)
            {
            string queryGetMinions = File.ReadAllText(@"..\..\SQLQuery-GetMinions.sql");
            string queryExecProcedure = File.ReadAllText(@"..\..\SQLQuery_ExecProcedure.sql");


            SqlConnection connection = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; 
                                                        Database = MinionsDB;
                                                        Integrated Security = true;");

            Console.Write("Enter Minion ID: ");
            int minionID = int.Parse(Console.ReadLine());

            connection.Open();
            using (connection)
                {
                SqlCommand cmdExecProc = new SqlCommand(queryExecProcedure, connection);
                SqlParameter paramID = new SqlParameter("@minionID", minionID);
                cmdExecProc.Parameters.Add(paramID);
                int affRows = cmdExecProc.ExecuteNonQuery();

                SqlCommand cmdGetMinions = new SqlCommand(queryGetMinions, connection);
                SqlParameter paramIDm = new SqlParameter("@minionID", minionID);
                cmdGetMinions.Parameters.Add(paramIDm);
                SqlDataReader readerMinions = cmdGetMinions.ExecuteReader();

                readerMinions.Read();
                Console.WriteLine($"{readerMinions[0]} {readerMinions[1]}");

                }
            }
        }
    }
