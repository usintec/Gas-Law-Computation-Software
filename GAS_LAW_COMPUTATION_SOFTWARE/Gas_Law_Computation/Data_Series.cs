using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Gas_Law_Computation
{
    class Data_Series
    {
        private Polyline lineSeries = new Polyline();
        private Brush lineColor;
        private double lineThickness = 1;
        private LinePatternEnum linePattern;
        private string seriesName = "Default Name";
        public Data_Series()
        {
            LineColor = Brushes.Green;
        }
        public enum LinePatternEnum
        {
            Solid = 1,
            Dash = 2,
            Dot = 3,
            DashDot = 4,
            None = 5
        }
        public Brush LineColor
        {
            get { return lineColor; }
            set { lineColor = value; }
        }
        public Polyline LineSeries
        {
            get { return lineSeries; }
            set { lineSeries = value; }
        }
        public double LineThickness
        {
            get { return lineThickness; }
            set { lineThickness = value; }
        }
        public LinePatternEnum LinePattern
        {
            get { return linePattern; }
            set { linePattern = value; }
        }
        public string SeriesName
        {
            get { return seriesName; }
            set { seriesName = value; }
        }
        public void AddLinePattern()
        {
            LineSeries.Stroke = LineColor;
            LineSeries.StrokeThickness = LineThickness;
            switch (LinePattern)
            {
                case LinePatternEnum.Dash:
                    LineSeries.StrokeDashArray =
                    new DoubleCollection(new double[2] { 4, 3 });
                    break;
                case LinePatternEnum.Dot:
                    LineSeries.StrokeDashArray =
                    new DoubleCollection(
                    new double[2] { 1, 2 });
                    break;
                case LinePatternEnum.DashDot:
                    LineSeries.StrokeDashArray =
                    new DoubleCollection(
                    new double[4] { 4, 2, 1, 2 });
                    break;
                case LinePatternEnum.None:
                    LineSeries.Stroke = Brushes.Transparent;
                    break;
            }
        }
    }
}
