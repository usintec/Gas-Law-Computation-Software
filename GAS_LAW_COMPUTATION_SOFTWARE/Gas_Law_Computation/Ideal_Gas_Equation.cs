using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Law_Computation
{
    class Ideal_Gas_Equation : Computation
    {
        public Dictionary<double, double> Compute_Automation(double known_item, double known_value,
            List<double> list_of_unknown_item, bool volume = true)
        {
            Dictionary<double, double> Authomation = new Dictionary<double, double>();

            return Authomation;
        }
        public double Compute_Pressure(double Mole, double Temperature, double Volume)
        {
            double Pressure = (Mole * Gas_Constant * Temperature) / Volume;
            return Pressure;
        }
        public double Compute_Volume(double Mole, double Temperature, double Pressure)
        {
            double Volume = (Mole * Gas_Constant * Temperature) / Pressure;
            return Volume;
        }
        public double Compute_Mole(double Pressure, double Volume, double Temperature)
        {
            double Mole = (Pressure * Volume) / (Gas_Constant * Temperature);
            return Mole;
        }
        public double Compute_Temperature(double Pressure, double Volume, double Mole)
        {
            double Temperature = (Pressure * Volume) / (Mole * Gas_Constant);
            return Temperature;
        }
    }
}
