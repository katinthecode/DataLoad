using System;
namespace DataLoad
{
    public class StockValue
    {
        public StockValue(){}

        public StockValue(int id, int companyId, DateTime date, Double open, Double high, Double low, Double close, Double adjClose, int volume)
        {
            this.Id = id;
            this.CompanyId = companyId;
            this.Date = date;
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.AdjClose = adjClose;
            this.Volume = volume;
        }

        //Create a new object using csv line
        public StockValue(string csvLine, int companyId)
        {
            string[] values = csvLine.Split(',');
            this.CompanyId = companyId;
            this.Date = Convert.ToDateTime(values[0]);
            this.Open = Convert.ToDouble(values[1]);
            this.High = Convert.ToDouble(values[2]);
            this.Low = Convert.ToDouble(values[3]);
            this.Close = Convert.ToDouble(values[4]);
            this.AdjClose = Convert.ToDouble(values[5]);
            this.Volume = Convert.ToInt32(values[6]);
        }

        public int Id;
        public int CompanyId;
        public DateTime Date;
        public Double Open;
        public Double High;
        public Double Low;
        public Double Close;
        public Double AdjClose;
        public int Volume;
    }
}
