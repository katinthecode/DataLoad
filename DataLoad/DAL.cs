using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLoad
{
    internal class DAL
    {
        string dataSource = "katinthecode.database.windows.net";
        string userId = "kantlitz";
        string password = "Bonjour1";
        string initialCatalog = "katinthecode";

        public void InsertStockValueList(List<StockValue> stockValues)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = dataSource;
            builder.UserID = userId;
            builder.Password = password;
            builder.InitialCatalog = initialCatalog;

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    foreach (StockValue stockValue in stockValues)
                    {
                        //exe: insert into aapl values ('2023-05-17', 171.710007, 172.929993, 170.419998, 172.690002, 172.230225, 57951600)
                        String sql = "insert into [dbo].[stockValues]"
                        + " values "
                        + "(" + stockValue.CompanyId + ", "
                        + "'" + stockValue.Date.ToString("yyyy-MM-dd") + "', "
                        + stockValue.Open + ", "
                        + stockValue.High + ", "
                        + stockValue.Low + ", "
                        + stockValue.Close + ", "
                        + stockValue.AdjClose + ", "
                        + stockValue.Volume + ")";

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

        public int GetCompanyId(string company)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = dataSource;
            builder.UserID = userId;
            builder.Password = password;
            builder.InitialCatalog = initialCatalog;

            int companyId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    
                    String sql = "select id from company where company = '" + company.ToUpper() + "'";

                    //Console.WriteLine(sql);

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            companyId = (int)reader["id"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return companyId;
        }
    }
}
