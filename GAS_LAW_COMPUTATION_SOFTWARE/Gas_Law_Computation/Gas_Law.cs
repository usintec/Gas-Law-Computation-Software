using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace Gas_Law_Computation
{
    class Gas_Law
    {
        private Chart_Style_Grid_Lines cs;
        private Data_Collection dc = new Data_Collection();
        private Data_Series ds = new Data_Series();

        TextBlock tbTitle; TextBlock tbXLabel; TextBlock tbYLabel;
        
        public Gas_Law(Canvas chartcanvas, Canvas textcanvas, TextBlock tbTitle,
            TextBlock tbYLabel, TextBlock tbXLabel)
        {
            this.tbTitle = tbTitle;
            this.tbXLabel = tbXLabel;
            this.tbYLabel = tbYLabel;

            //this.AddChart(chartcanvas, textcanvas, tbTitle, tbYLabel, tbXLabel);
        }
        public Gas_Law()
        {

        }
        public Int32 AddChartSineConsine(Canvas chartcanvas, Canvas textcanvas, TextBlock tbTitle, 
            TextBlock tbXLabel, TextBlock tbYLabel)
        {
            cs = new Chart_Style_Grid_Lines();
            cs.ChartCanvas = chartcanvas;
            cs.TextCanvas = textcanvas;
            cs.Title = "Sine and Cosine Chart";
            cs.Xmin = 0;
            cs.Xmax = 7;
            cs.Ymin = -1.5;
            cs.Ymax = 1.5;
            cs.YTick = 0.5;
            cs.GridlinePattern =
            Chart_Style_Grid_Lines.GridlinePatternEnum.Dot;
            cs.GridlineColor = Brushes.Black;
            cs.AddChartStyle(tbTitle, tbYLabel, tbXLabel);
            // Draw Sine curve:
            ds.LineColor = Brushes.Blue;
            ds.LineThickness = 3;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Sin(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);
            // Draw cosine curve:
            ds = new Data_Series();
            ds.LineColor = Brushes.Red;
            ds.LinePattern = Data_Series.LinePatternEnum.DashDot;
            ds.LineThickness = 3;
            for (int i = 0; i < 70; i++)
            {
                double x = i / 5.0;
                double y = Math.Cos(x);
                ds.LineSeries.Points.Add(new Point(x, y));
            }
            dc.DataList.Add(ds);
            dc.AddLines(chartcanvas, cs);
            return 0;
        }
        public List<Data_Series> return_datalist
        {
            get { return dc.DataList; }
        }
        public List<TextBlock> textblock_list
        {
            get { return cs.tb_list; }
        }
        /*public TextBlock return_textblock1
        {
            get { return cs.textblock1; }
        }
        public TextBlock return_textblock2
        {
            get { return cs.textblock2; }
        }*/
        /// <summary>
        /// integers settings array have the following members
        /// 1.xmin
        /// 2.xmax
        /// 3.ymin
        /// 4.ymax
        /// </summary>
        /// <param name="chartcanvas"></param>
        /// <param name="textcanvas"></param>
        /// <param name="tbTitle"></param>
        /// <param name="tbXLabel"></param>
        /// <param name="tbYLabel"></param>
        /// <param name="integers_settings"></param>
        /// <returns></returns>
        public Int32 AddChart(Canvas chartcanvas, Canvas textcanvas, TextBlock tbTitle,
            TextBlock tbXLabel, TextBlock tbYLabel, string chart_title, string xlable, string ylabel,
            double[] integers_settings, bool authomation = true, Dictionary < double,double> authomation_dic = null, 
            double[]pressure = null, double[] volume = null )
        {
            cs = new Chart_Style_Grid_Lines();
            cs.ChartCanvas = chartcanvas;
            cs.TextCanvas = textcanvas;
            cs.Title = chart_title;
            cs.Xmin = integers_settings[0];
            cs.Xmax = integers_settings[1];
            cs.Ymin = integers_settings[2];
            cs.Ymax = integers_settings[3];
            cs.XTick = integers_settings[1] / 10;
            cs.YTick = integers_settings[3] / 10;
            cs.XLabel = xlable;
            cs.YLabel = ylabel;
            cs.GridlinePattern = Chart_Style_Grid_Lines.GridlinePatternEnum.Dot;
            cs.GridlineColor = Brushes.DarkGreen;
            cs.AddChartStyle(tbTitle, tbYLabel, tbXLabel);
            // Draw Sine curve:
            ds.LineColor = Brushes.Blue;
            ds.LineThickness = 3;
            if(authomation)
            {
                //key is pressure and key value is volume
                foreach(double item in authomation_dic.Keys)
                {
                    ds.LineSeries.Points.Add(new Point(item, authomation_dic[item]));
                }
            }
            else if(!authomation)
            {
                Int32 counter = 0;
                foreach(double pressure_value in pressure)
                {
                    ds.LineSeries.Points.Add(new Point(pressure_value, volume[counter]));
                    counter++;
                }
            }
            dc.DataList.Add(ds);
            dc.AddLines(chartcanvas, cs);
            return 0;
        }
    }
}
    