using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gas_Law_Computation
{
     class Computation : Gas_Law
    {
        double Univesal_Gas_Constant = 0.08206;

        public double Gas_Constant
        {
            get { return Univesal_Gas_Constant; }
            set { Univesal_Gas_Constant = value; }
        }
        public double Compute_Boyles_Charles_Law(double Numerator1, double Numerator2, double Denominator)
        {
            double result = 0.0;
            try
            {
                result = (Numerator1 * Numerator2) / Denominator;
                return result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return double.Parse(null);
        }
        public double Compute_Gas_Equation_Pressure_Volume(double Mole, double Temperature, double Denominator)
        {
            double result = (Univesal_Gas_Constant * Mole * Temperature) / Denominator;
            return result;
        }
        public double Compute_Gas_Equation_Mole_Temperature(double Pressure, double Volume, double Denominator)
        {
            double result = (Pressure * Volume) / (Univesal_Gas_Constant * Denominator);
            return result;
        }
        /*public Dictionary<double, double> Compute_Automation(double known_item, double known_value,
            List<double> list_of_unknown_item, bool volume = true)
        {
            Dictionary<double, double> empty_dict = new Dictionary<double, double>();
            return empty_dict;
        }*/
    }
}
