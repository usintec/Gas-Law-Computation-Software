using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gas_Law_Computation
{
    class Boyles_Law : Conversion
    {
        public Dictionary<double, double> Compute_Automation(double known_item, double known_value,
            List<double> list_of_unknown_item, bool volume = true)
        {
             Dictionary<double, double> Authomation = new Dictionary<double, double>();
            try
            {
                double Constant = known_item * known_value;

                foreach (double item in list_of_unknown_item)
                {
                    double item_value = Constant / item;
                    item_value = Math.Round(item_value, 3, MidpointRounding.AwayFromZero);
                    Authomation.Add(item, item_value);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Authomation;
        }
    }
}
