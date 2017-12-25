using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gas_Law_Computation
{
    class Charles_Law : Conversion
    {
        public Dictionary<double, double> Compute_Automation(double known_item, double known_value,
            List<double> list_of_unknown_item, bool volume)
        {
            Dictionary<double, double> Authomation = new Dictionary<double, double>();
            try
            {
                double Constant = known_item / known_value;
                if (volume)
                {
                    foreach (double item in list_of_unknown_item)
                    {
                        double item_value = item / Constant;
                        item_value = Math.Round(item_value, 3, MidpointRounding.AwayFromZero);
                        Authomation.Add(item, item_value);
                    }
                }
                else if (!volume)
                {
                    foreach (double item in list_of_unknown_item)
                    {
                        double item_value = item * Constant;
                        item_value = Math.Round(item_value, 3, MidpointRounding.AwayFromZero);
                        Authomation.Add(item, item_value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Authomation;
        }
        /*public double Compute_V1(double V2, double T1, double T2)
        {
            return Compute_Boyles_Charles_Law(V2, T1, T2);
        }
        public double Compute_V2(double P1, double T2, double T1)
        {
            return Compute_Boyles_Charles_Law(P1, T2, T1);
        }
        public double Compute_T1(double V1,double T2,double V2)
        {
            return Compute_Boyles_Charles_Law(V1, T2, V2);
        }
        public double Compute_T2(double V2, double T1, double V1)
        {
            return Compute_Boyles_Charles_Law(V2, T1, V1);
        }*/
    }
}
