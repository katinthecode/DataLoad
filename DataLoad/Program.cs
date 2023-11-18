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
            //get company by removing file path and .csv
            string file_path = @"C:/dev/DataLoad/DataLoad/csv/MSFT.csv";
            string[] path_strings = file_path.Split('/');
            string company = path_strings[path_strings.Length - 1];
            company = company.Replace(".csv", "");

            //Console.WriteLine(company);

            DAL dal = new DAL();

            List<StockValue> stockValue = GetListFromCSVFile(file_path, dal.GetCompanyId(company));
            dal.InsertStockValueList(stockValue);

            Console.ReadLine();
        }

        private static List<StockValue> GetListFromCSVFile(string csv_file_path, int companyId)
        {
            List<StockValue> stockValues = new List<StockValue>();

            try
            {
                //get all lines except the first listing columns
                var lines = File.ReadAllLines(csv_file_path).Skip(1);
                foreach (string line in lines)
                    stockValues.Add(new StockValue(line, companyId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            //Console.WriteLine("Count:" + aapls.Count);

            return stockValues;
        }

        
    }
}
