using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace DataLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            string file_path = @"C:/dev/DataLoad/DataLoad/AAPL.csv";

            List<AAPL> aapls = GetListFromCSVFile(file_path);
            InsertAAPLList(aapls);

            Console.ReadLine();
        }

        private static List<AAPL> GetListFromCSVFile(string csv_file_path)
        {
            List<AAPL> aapls = new List<AAPL>();

            try
            {
                //get all lines except the first listing columns
                var lines = File.ReadAllLines(csv_file_path).Skip(1);
                foreach (string line in lines)
                    aapls.Add(new AAPL(line));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            //Console.WriteLine("Count:" + aapls.Count);

            return aapls;
        }

        public static void InsertAAPLList(List<AAPL> aapls)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "katinthecode.database.windows.net";
            builder.UserID = "kantlitz";
            builder.Password = "********";
            builder.InitialCatalog = "katinthecode";

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    foreach (AAPL aapl in aapls)
                    {
                        //exe: insert into aapl values ('2023-05-17', 171.710007, 172.929993, 170.419998, 172.690002, 172.230225, 57951600)
                        String sql = "insert into [dbo].[aapl]"
                        + " values "
                        + "('" + aapl.Date.ToString("yyyy-MM-dd") + "', "
                        + aapl.Open + ", "
                        + aapl.High + ", "
                        + aapl.Low + ", "
                        + aapl.Close + ", "
                        + aapl.AdjClose + ", "
                        + aapl.Volume + ")";

                        //Console.WriteLine(sql);

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
