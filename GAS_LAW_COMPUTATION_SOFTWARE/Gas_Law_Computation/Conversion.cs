using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Law_Computation
{
     class Conversion : Computation
    {
        public double volume_conversion_from_cm_cube_to_liter(double value_in_cm_cube)
        {
            double value_in_liter = value_in_cm_cube * 1000;
            return value_in_liter;
        }
        public double volume_conversion_from_liter_to_cm_cube(double value_in_liter)
        {
            double value_in_cm_cube = value_in_liter / 1000;
            return value_in_cm_cube;
        }
        public double pressure_conversion_from_torrs_to_atm(double value_in_torrs)
        {
            double value_in_atm = value_in_torrs / 760;
            return value_in_atm;
        }
        public double pressure_conversion_from_atm_to_torrs(double value_in_atm)
        {
            double value_in_torrs = value_in_atm * 760;
            return value_in_torrs;
        }
        public double temperature_conversion_from_celsius_to_kelvin(double value_celsius)
        {
            double value_in_kelvin = value_celsius + 273.15;
            return value_in_kelvin;
        }
        public double temperature_conversion_from_kelvin_to_celsius(double value_in_kelvin)
        {
            double value_celsius = value_in_kelvin - 273.15;
            return value_celsius;
        }
    }
}
