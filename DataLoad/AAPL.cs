using System;
namespace DataLoad
{
    public class AAPL
    {
        public AAPL(){}

        public AAPL(DateTime date, Double open, Double high, Double low, Double close, Double adjClose, int volume)
        {
            this.Date = date;
            this.Open = open;
            this.High = high;
            this.Low = low;
            this.Close = close;
            this.AdjClose = adjClose;
            this.Volume = volume;
        }

        //Create a new object using csv line
        public AAPL(string csvLine)
        {
            string[] values = csvLine.Split(',');
            this.Date = Convert.ToDateTime(values[0]);
            this.Open = Convert.ToDouble(values[1]);
            this.High = Convert.ToDouble(values[2]);
            this.Low = Convert.ToDouble(values[3]);
            this.Close = Convert.ToDouble(values[4]);
            this.AdjClose = Convert.ToDouble(values[5]);
            this.Volume = Convert.ToInt32(values[6]);
        }


        public DateTime Date;
        public Double Open;
        public Double High;
        public Double Low;
        public Double Close;
        public Double AdjClose;
        public int Volume;
    }
}
