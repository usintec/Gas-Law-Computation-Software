using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace Gas_Law_Computation
{
     class Data_Collection
    {
        private List<Data_Series> dataList;
        public Data_Collection()
        {
            dataList = new List<Data_Series>();
        }
        public List<Data_Series> DataList
        {
            get { return dataList; }
            set { dataList = value; }
        }
        public void AddLines(Canvas canvas, Chart_Style cs)
        {
            
            int j = 0;
            foreach (Data_Series ds in DataList)
            {
                if (ds.SeriesName == "Default Name")
                {
                    ds.SeriesName = "DataSeries" +
                    j.ToString();
                }
                ds.AddLinePattern();
                for (int i = 0; i < ds.LineSeries.Points.Count; i++)
                {
                    ds.LineSeries.Points[i] =
                    cs.NormalizePoint(ds.LineSeries.Points[i]);
                }
                canvas.Children.Add(ds.LineSeries);
                j++;
            }
        }
    }
}
